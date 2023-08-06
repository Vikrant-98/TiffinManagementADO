using Business.Interface;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Repository.Interface;
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
                List<TiffinDetails> tiffinDetails = new List<TiffinDetails>();
                List<TiffinDetails>? listTiffin =  await _tiffinServices.GetAllTiffin().ConfigureAwait(false);
                var TiffinWithModeRating = listTiffin.GroupBy(x => x.Id);
                foreach (var item in TiffinWithModeRating)
                {
                    int avgRating = 0;
                    try
                    {
                        avgRating = item.Sum(x => x.Rating) / item.Count();
                    }
                    catch (Exception)
                    {
                        avgRating = 0;
                    }
                    
                    var tempTiffin = item.First();
                    tempTiffin.Rating = avgRating;
                    tiffinDetails.Add(tempTiffin);
                }
                return tiffinDetails;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public async Task<AddResponse> AddTiffin(AddTiffinRequest addTiffin, int Id, IFormFile formFile)
        {
            try
            {
                var ImageUrl = await PrepareImageUrl(formFile).ConfigureAwait(false);
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
        
        public async Task<AddResponse> EditTiffin(AddTiffinModifier editTiffin, IFormFile Image)
        {
            try
            {
                var ImageUrl = await PrepareImageUrl(Image).ConfigureAwait(false);
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

        public async Task<AddResponse> AddReview(AddTiffinReview addTiffinReview, int Id)
        {
            try
            {

                return await _tiffinServices.AddTiffinRatings(addTiffinReview, Id).ConfigureAwait(false);

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
