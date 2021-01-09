namespace CompuRent.DiegoTest.Services.Helpers
{
    using CompuRent.DiegoTest.Models.DTOs;
    using CompuRent.DiegoTest.Models.Entities;
    using System;

    /// <summary>
    /// Common Helper
    /// </summary>
    public static class CommonHelper
    {
        /// <summary>
        /// Base64s the encode.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <returns>Encoded string</returns>
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Base64s the decode.
        /// </summary>
        /// <param name="base64EncodedData">The base64 encoded data.</param>
        /// <returns>Decoded String</returns>
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        /// <summary>
        /// Converts to cliententity.
        /// </summary>
        /// <param name="clientRegisterDTO">The client register dto.</param>
        /// <returns>Client Entity</returns>
        public static ClientEntity ToClientEntity(ClientRegisterDTO clientRegisterDTO)
        {
            return new ClientEntity()
            {
                Address = clientRegisterDTO.Address,
                Email = clientRegisterDTO.Email,
                Name = clientRegisterDTO.Name,
                Password = Base64Encode(clientRegisterDTO.Password),
                Phone = clientRegisterDTO.Phone,
                ClientId = clientRegisterDTO.ClientId
            };
        }
    }
}
