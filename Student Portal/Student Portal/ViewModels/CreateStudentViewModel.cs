﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Student_Portal.ViewModels
{
    public class CreateStudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Enrolled { get; set; }
        public IList<SelectListItem> Courses { get; set; }
    }
}
