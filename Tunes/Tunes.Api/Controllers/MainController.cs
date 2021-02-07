using Tunes.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;
using Tunes.Business.Notifications;
using System.Net.Http;
using System.IO;
using ClosedXML.Excel;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Tunes.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotifier _notifier;
        public readonly IUser AppUser;

        protected Guid UserId { get; set; }
        protected bool UserAuthenticated { get; set; }

        protected MainController(INotifier notifier, IUser appUser)
        {
            _notifier = notifier;
            AppUser = appUser;

            if (appUser.IsAuthenticated())
            {
                UserId = appUser.GetUserId();
                UserAuthenticated = true;
            }
        }

        protected bool ValidOperation()
        {
            return !_notifier.HasNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifier.GetNotifications().Select(n => n.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyInvalidModelError(modelState);

            return CustomResponse();
        }

        protected void NotifyInvalidModelError(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);

            foreach (var error in errors)
            {
                var errorMessage = error.Exception == null ? error.ErrorMessage : error.Exception.Message;

                NotifyError(errorMessage);
            }
        }

        protected void NotifyError(string errorMessage)
        {
            _notifier.Handle(new Notification(errorMessage));
        }

        protected async Task<IActionResult> GerarArquivoExcel(XLWorkbook workbook, string nomeArquivo)
        {
            var ms = new MemoryStream();

            workbook.SaveAs(ms);

            ms.Seek(0, SeekOrigin.Begin);

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(ms);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = nomeArquivo;
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

            response.Content.Headers.ContentLength = ms.Length;
            ms.Seek(0, SeekOrigin.Begin);

            return File(await response.Content.ReadAsByteArrayAsync(), response.Content.Headers.ContentType.ToString());
        }
    }
}