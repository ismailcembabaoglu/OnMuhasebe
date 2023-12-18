using OnMuhasebe.Application.DTOs;
using OnMuhasebe.Application.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.IServices
{
    public interface IKdvService
    {
        public Task<List<KdvDTO>> GetKdvs();
        public Task<KdvDTO> CreateKdv(KdvDTO Kdv);
        public Task<KdvDTO> UpdateKdv(KdvDTO Kdv);
        public Task<bool> DeleteKdvId(Guid id);
        public Task<KdvDTO> GetKdvId(Guid id);

        //Bu yöntem daha basit bir yapı sunar. Sadece bir liste döner ve hata durumlarını ele almak için daha az kontrol sağlar.
        //Ancak, daha basit ve doğrudan bir kullanım sunabilir.

        // Tüm KDV oranlarını getiren metot.
        //Task<ServiceResponse<IEnumerable<KdvDto>>> GetAllKdvRatesAsync();

        // Belirli bir KDV oranını getiren metot.
        //Task<ServiceResponse<KdvDto>> GetKdvRateByIdAsync(Guid kdvId);

        // Yeni bir KDV oranı ekleyen metot.
        //Task<ServiceResponse<KdvDto>> AddKdvRateAsync(KdvDto kdvDto);

        // Mevcut bir KDV oranını güncelleyen metot.
        //Task<ServiceResponse<KdvDto>> UpdateKdvRateAsync(Guid kdvId, KdvDto updatedKdvDto);

        // Belirli bir KDV oranını silen metot.
        //Task<BaseResponse> DeleteKdvRateAsync(Guid kdvId);

        //Bu yöntem, işlemin başarılı olup olmadığını ve bir hata durumunda hatanın nasıl ele alınacağını belirten daha geniş bir yapı sunar.
        //ServiceResponse sınıfı, işlemin başarı durumunu ve geri dönen veriyi içerir. Bu yaklaşım, servis katmanınızda işlemlerin daha geniş bir kontrolünü sağlar.
    }
}
