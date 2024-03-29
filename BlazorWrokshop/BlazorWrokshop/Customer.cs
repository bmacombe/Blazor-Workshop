﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWrokshop
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Not a valid Email Address")]
        [StringLength(50, ErrorMessage = "Email is too long.")]
        public string Email { get; set; }

    }
}
