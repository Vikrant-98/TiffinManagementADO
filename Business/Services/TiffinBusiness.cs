﻿using Business.Interface;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Repository.Interface;
using System.Data.SqlClient;
using TiffinManagement.MapperServices;
using TiffinManagement.ModelServices.Request;
using TiffinManagement.ModelServices.Response;

namespace Business.Services
{
    public class TiffinBusiness : ITiffinBusiness
    {
        private readonly ITiffinServices _tiffinServices;
        private readonly DatabaseMapper _databaseMapper;
        public TiffinBusiness(ITiffinServices stockService, DatabaseMapper databaseMapper)
        {
            _tiffinServices = stockService;
            _databaseMapper = databaseMapper;   
        }

        public async Task<List<TiffinDetails>> GetAllTiffin()
        {
            try
            {
                 return await _tiffinServices.GetAllTiffin().ConfigureAwait(false);                 
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public async Task<AddResponse> AddTiffin(AddTiffinRequest addTiffin, int Id)
        {
            try
            {
                var ImageUrl = await PrepareImageUrl(addTiffin.Image).ConfigureAwait(false);
                AddTiffin addTiffinModifier = new AddTiffin() 
                {
                    Description = addTiffin.Description,
                    TiffinAddress = addTiffin.TiffinAddress,
                    ImageURL = ImageUrl,
                    Name = addTiffin.Name,
                    Price = addTiffin.Price,
                };

                return await _tiffinServices.AddTiffin(addTiffinModifier,Id).ConfigureAwait(false);
                
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public async Task<AddResponse> EditTiffin(AddTiffinModifier editTiffin)
        {
            try
            {
                var ImageUrl = await PrepareImageUrl(editTiffin.Image).ConfigureAwait(false);
                return await _tiffinServices.EditTiffin(editTiffin, ImageUrl).ConfigureAwait(false);                
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public async Task<AddResponse> DeleteTiffin(int id)
        {            
            try
            {
                return await _tiffinServices.DeleteTiffin(id).ConfigureAwait(false);                
            }
            catch (Exception)
            {
                throw;
            }

        }

        private async Task<string> PrepareImageUrl(IFormFile ImageFile) 
        {
            Account account = new Account(
                      "dw9jw58vv",
                      "438317129373873",
                      "9ymO_S3VR-o1qq5xnTRwtbkle0w");

            Cloudinary cloudinary = new Cloudinary(account);

            var path = ImageFile.OpenReadStream();

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(ImageFile.FileName, path)
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            return uploadResult.Url.ToString();
        }

    }
}
