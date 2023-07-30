using Business.Interface;
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
                 SqlDataReader? dataReader = await _tiffinServices.GetAllTiffin().ConfigureAwait(false);
                 List<TiffinDetails>? TiffinList = _databaseMapper.GetAllTiffin(dataReader);
                return TiffinList;
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

                SqlDataReader? dataReader = await _tiffinServices.AddTiffin(addTiffinModifier,Id).ConfigureAwait(false);
                AddResponse? response = _databaseMapper.AddUpdateDeleteResponse(dataReader);
                return response;
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
                SqlDataReader? dataReader = await _tiffinServices.EditTiffin(editTiffin, ImageUrl).ConfigureAwait(false);
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
