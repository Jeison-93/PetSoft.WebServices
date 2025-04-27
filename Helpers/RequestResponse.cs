namespace PetSoft.WebServices.Helpers
{
    /// <summary>
    /// <T> hace que las respuestas sean dinamicas
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RequestResponse<T>
    {
        /// <summary>
        /// mensaje de respuesta del api
        /// </summary>
        public string? Message { get; set; } 
        /// <summary>
        /// indicador de exito o fallo
        /// </summary>
        public bool IsSuccessful { get; set; }
        /// <summary>
        /// indicador de error del api
        /// </summary>
        public bool IsError { get; set; }

        /// <summary>
        /// mensaje de error
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// respuesta de la peticion
        /// </summary>
            public T Result { get; set; }

        /// <summary>
        /// metodo que indica que se presento un error en la peticion
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public RequestResponse<T> CreateError(string error)
        {
            IsSuccessful = false;
            IsError = true;
            ErrorMessage = error ?? string.Empty;
            return this;
        }
        /// <summary>
        /// metodo que indica que la peticion fue exitosa y devuelve un valor generico.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public RequestResponse<T> CreateSuccessful(T result)
        {
            IsSuccessful = true;
            IsError = false;
            Result = result;
            return this;
        }
        /// <summary>
        /// peticion exitosa, devulve un valor generico y un mensaje
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public RequestResponse<T> CreateSuccessful(T result, string message)
        {
            IsSuccessful = true;
            IsError = false;
            Result = result;
            Message = message ?? string.Empty;
            return this;
        }
        /// <summary>
        /// peticion fallida, no genera error.
        /// </summary>
        /// <param name="messages"></param>
        /// <returns></returns>
        public RequestResponse<T> CreateUnsuccessful(string messages)
        {
            IsSuccessful = false;
            IsError = false;
            Message = messages ?? string.Empty;
            return this;
        }




    }
}
