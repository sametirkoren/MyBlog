using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.WebApi.Enums;
using MyBlog.WebApi.Models;

namespace MyBlog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public async Task<UploadModel> UploadFile(IFormFile file , string contentType)
        {
            UploadModel uploadModel = new UploadModel();

            if (file != null)
            {
                if (file.ContentType != contentType)
                {
                    uploadModel.ErrorMessage = "uygunsuz dosya türü";
                    uploadModel.UploadState = UploadState.Error;
                    return uploadModel;
                }
                else
                {
                    var newName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img" + newName);
                    var stream = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(stream);
                    uploadModel.NewName = newName;
                    uploadModel.UploadState = UploadState.Succcess;
                    return uploadModel;

                }
               
            }
            uploadModel.ErrorMessage = "Dosya yok";
            uploadModel.UploadState = UploadState.NotExist;
            return uploadModel;

        }
    }
}