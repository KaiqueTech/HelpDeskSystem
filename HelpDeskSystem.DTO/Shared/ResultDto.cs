﻿namespace HelpDeskSystem.DTO.DTOs.Shared
{
    public class ResultDto<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public static ResultDto<T> Ok(T data, string message = "") =>
            new ResultDto<T> { Success = true, Data = data, Message = message };

        public static ResultDto<T> Fail(string message) =>
            new ResultDto<T> { Success = false, Message = message };
    }
}