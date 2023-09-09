using System.Net;

namespace Atilim.Shared.Dtos
{
    public sealed class ResponseDto<T>
    {
        public T Data { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public List<string> Errors { get; set; }

        /// <summary>
        /// Response Başarılı Durumu
        /// </summary>
        /// <param name="data"></param>
        /// <param name="httpStatusCode"></param>
        /// <returns></returns>
        public static ResponseDto<T> Success(T data, HttpStatusCode httpStatusCode)
        {
            return new ResponseDto<T> { Data = data, HttpStatusCode = httpStatusCode, IsSuccessful = true };
        }

        /// <summary>
        /// Response Başarılı Durumu (Success Overload method'u olarak oluşturuldu. Sadece StatusCode alıyor.)
        /// </summary>
        /// <param name="httpStatusCode"></param>
        /// <returns></returns>
        public static ResponseDto<T> Success(HttpStatusCode httpStatusCode)
        {
            return new ResponseDto<T> { Data = default(T), HttpStatusCode = httpStatusCode, IsSuccessful = true };
        }

        /// <summary>
        /// Response Başarısız Durumu (Birden çok hata için)
        /// </summary>
        /// <param name="errors"></param>
        /// <param name="httpStatusCode"></param>
        /// <returns></returns>
        public static ResponseDto<T> Fail(List<string> errors, HttpStatusCode httpStatusCode)
        {
            return new ResponseDto<T> { HttpStatusCode = httpStatusCode, Errors = errors, IsSuccessful = false };
        }

        /// <summary>
        /// Response Başarısız Durumu (Tek hata için Overload method)
        /// </summary>
        /// <param name="error"></param>
        /// <param name="httpStatusCode"></param>
        /// <returns></returns>
        public static ResponseDto<T> Fail(string error, HttpStatusCode httpStatusCode)
        {
            return new ResponseDto<T> { Errors = new List<string>() { error }, HttpStatusCode = httpStatusCode, IsSuccessful = false };
        }
    }
}

