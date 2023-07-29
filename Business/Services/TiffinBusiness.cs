using Business.Interface;
using Repository.Interface;
using System.Data.SqlClient;
using System.Data;
using TiffinManagement.DatabaseServices;
using TiffinManagement.ModelServices.ProcessModel;
using TiffinManagement.MapperServices;
using TiffinManagement.ModelServices.Response;
using TiffinManagement.ModelServices.Request;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

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
                 SqlDataReader? dataReader = await _tiffinServices.GetAllTiffin().ConfigureAwait(false);
                 List<TiffinDetails>? TiffinList = _databaseMapper.GetAllTiffin(dataReader);
                return TiffinList;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public async Task<AddResponse> AddTiffin(AddTiffin addTiffin, int Id)
        {
            try
            {

                Account account = new Account(
                      "dw9jw58vv",
                      "438317129373873",
                      "9ymO_S3VR-o1qq5xnTRwtbkle0w");

                Cloudinary cloudinary = new Cloudinary(account);

                var path = addTiffin.Image.OpenReadStream();

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(addTiffin.Image.FileName, path)
                };

                var uploadResult = await cloudinary.UploadAsync(uploadParams);

                AddTiffinModifier addTiffinModifier = new AddTiffinModifier() 
                {
                    Description = addTiffin.Description,
                    Address = addTiffin.Address,
                    ImageUrl = uploadResult.Url.ToString(),
                    Name = addTiffin.Name,
                    Price = addTiffin.Price,
                };

                SqlDataReader? dataReader = await _tiffinServices.AddTiffin(addTiffinModifier,Id).ConfigureAwait(false);
                AddResponse? response = _databaseMapper.AddUpdateDeleteResponse(dataReader);
                return response;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public async Task<AddResponse> EditTiffin(AddTiffinModifier addTiffin)
        {
            try
            {
                SqlDataReader? dataReader = await _tiffinServices.EditTiffin(addTiffin).ConfigureAwait(false);
                AddResponse? response = _databaseMapper.AddUpdateDeleteResponse(dataReader);
                return response;
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
                SqlDataReader? dataReader = await _tiffinServices.DeleteTiffin(id).ConfigureAwait(false);
                AddResponse?  response = _databaseMapper.AddUpdateDeleteResponse(dataReader);
                return response;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
