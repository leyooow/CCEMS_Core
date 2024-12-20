﻿using Application.Models.DTOs.Common;
using Application.Models.DTOs.Employee;
using Application.Models.DTOs.ExceptionsMgmt;
using Application.Models.DTOs.SubExceptions;
using Application.Models.Responses;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Services
{
    public interface ISubExceptionsService
    {
        Task<GenericResponse<PagedResult<ExceptionCodeRevsDTO>>> GetSubExceptionLists(int? pageNumber = 1, int? pageSize = 10, string? searchString = null, string? currentFilter = null);
        Task<GenericResponse<SubExceptionsDetailsDTO>> GetSubExceptionDetails(string subERN);
        Task<GenericResponse<object>> DeleteSubException(string subRefNo, string deleteSubExceptionRemarks);
        Task<GenericResponse<object>> UpdateSubException(string subRefNo, DeviationStatusDTO NewStatus, DateTime? TaggingDate, string ExItemRefNo,
            string data, bool isDelete = false);
        Task<GenericResponse<object>> ApproveSubException(string subRefNo, SubExceptionsDetailsDTO value);
        Task<GenericResponse<object>> RejectSubException(string subRefNo, SubExceptionsDetailsDTO value, string? remarks);

    }
}