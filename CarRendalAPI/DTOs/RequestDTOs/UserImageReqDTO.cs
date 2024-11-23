﻿using CarRendalAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.DTOs.RequestDTOs
{
    public class UserImageReqDTO
    {
        [Required(ErrorMessage = "Image URL is required.")]
        [Url(ErrorMessage = "Please provide a valid URL for the image.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Image type is required.")]
        public UserImageType ImageType { get; set; }
    }
}