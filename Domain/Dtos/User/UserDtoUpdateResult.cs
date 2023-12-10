using System;

namespace Api.Domain.Dtos.User
{
    public class UserDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
