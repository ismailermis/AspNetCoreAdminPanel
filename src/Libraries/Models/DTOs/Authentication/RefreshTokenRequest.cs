﻿namespace Models.DTOs.Authentication
{
    public class RefreshTokenRequest
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
