using System.Text.Json.Serialization;

namespace BrightAkademi.Shared.ResponseDTOs
{
    public class Response<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        [JsonIgnore]
        public bool IsSucceeded { get; set; }

        /// <summary>
        /// Bu metot, işlemin başarılı olduğu durumlarda başarılı bir cevapla birlikte veriyive durum kodunu döndürmek için kullanılır.
        /// </summary>
        /// <param name="data">Geri döndürülecek veri</param>
        /// <param name="statusCode">Geri döndürülecek durum kodu ör: 201, 401 vs</param>
        /// <returns>Response<typeparamref name="T"/>.</returns>
        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T>
            {
                Data = data,
                StatusCode = statusCode,
                IsSucceeded = true
            };
        }
        /// <summary>
        /// Bu metot, geriye başarılı bir cevap olarak sadece durum kodu döndürmek için kullanılır.
        /// </summary>
        /// <param name="statusCode">Geri döndürülecek durum kodu</param>
        /// <returns>Response<typeparamref name="T"/></returns>
        public static Response<T> Success(int statusCode)
        {
            return new Response<T>
            {
                Data = default(T),
                StatusCode = statusCode,
                IsSucceeded = true
            };
        }

        /// <summary>
        /// Bu metot, geriye başarısız bir cevap olarak hata listesini ve durum kodurnu döndürmek için kullanılır.
        /// </summary>
        /// <param name="errors">Döndürülecek hata listesi</param>
        /// <param name="statusCode">Döndürülecek durum kodu ör: 401, 503 vb.</param>
        /// <returns>Response<typeparamref name="T"/></returns>
        public static Response<T> Fail(List<string> errors, int statusCode)
        {
            return new Response<T>
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSucceeded = false
            };
        }

        /// <summary>
        /// Bu metot, geriye başarısız bir cevap olarak içinde bir hata olan hata listesini ve durum kodurnu döndürmek için kullanılır.
        /// </summary>
        /// <param name="errors">Döndürülecek hata listesi</param>
        /// <param name="statusCode">Döndürülecek durum kodu ör: 401, 503 vb.</param>
        /// <returns>Response<typeparamref name="T"/></returns>
        public static Response<T> Fail(string error, int statusCode)
        {
            return new Response<T>
            {
                Errors = new List<string> { error },
                StatusCode = statusCode,
                IsSucceeded = false
            };
        }
    }
}


/*
 
 api dönüş kodları 200 202 400 404 500 vs bunları acıklar mısın nerde hangisini kullanmam lazım
ChatGPT
API dönüş kodları, bir HTTP isteğinin sonucunu ve başarılı veya başarısız olduğunu belirlemek için kullanılır. İşte yaygın olarak kullanılan bazı HTTP dönüş kodları ve açıklamaları:

200 OK: İsteğiniz başarılı bir şekilde işlendi ve istenen kaynak bulundu. Bu genellikle başarılı GET istekleri için kullanılır.

201 Created: İsteğiniz başarıyla işlendi ve yeni bir kaynak oluşturuldu. Genellikle POST isteklerinin sonucunda kullanılır.

204 No Content: İsteğiniz başarılı bir şekilde işlendi, ancak yanıtta herhangi bir veri yok. Genellikle DELETE isteklerinin sonucunda kullanılır.

400 Bad Request: İstek geçersiz veya eksik verilere sahip. İstemci tarafından gönderilen verilerin doğru olmadığını veya beklenen bir şekilde biçimlenmediğini belirtir.

401 Unauthorized: İstek için kimlik doğrulaması gereklidir. Kullanıcı yetkilendirilmemiş veya oturum açmamış olabilir.

403 Forbidden: İstek yapılmış olsa bile, istemcinin kaynağa erişim izni yoktur. Kullanıcı yetkilendirilmemiş olabilir.

404 Not Found: İstek yapılan kaynak bulunamadı. URL'de hedeflenen kaynak mevcut değilse kullanılır.

422 Unprocessable Entity: İstek geçerli olabilir, ancak sunucu tarafından işlenemedi. Genellikle istemci tarafından gönderilen verilerin geçerli olmasına rağmen, 
işlenemediği durumlar için kullanılır.

500 Internal Server Error: Sunucu bir hata ile karşılaştı ve isteği işleyemedi. Bu, sunucu tarafındaki beklenmeyen hataları belirtir.

503 Service Unavailable: Sunucu geçici olarak hizmet veremiyor veya bakım modunda. İstemci, isteğini daha sonra yeniden denemelidir.

Bu dönüş kodlarını kullanırken, her durumu uygun şekilde ele almalısınız. Başarılı işlemler için 200 veya 201 gibi başarı kodları kullanılırken, 
hatalı veya eksik istekler için 400 veya 422 gibi hata kodları kullanılır. Sunucu tarafındaki hatalar için 500 veya 503 gibi hata kodları kullanılabilir.

İstemciye hangi dönüş kodunu döndüreceğinizi, isteğin türüne, durumuna ve işlemine bağlı olarak seçmelisiniz. 
Ayrıca, dönüş kodlarına ek olarak yanıtın içeriğinde daha fazla ayrıntı sağlamak için özel hata mesajları veya durum açıklamaları da ekleyebilirsiniz.
 
 
 
 */