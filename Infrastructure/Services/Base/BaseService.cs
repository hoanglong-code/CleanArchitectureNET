using AutoMapper;
using FluentValidation;
using Infrastructure.Constants;
using Infrastructure.Enums;
using Infrastructure.Exceptions.Extend;
using Infrastructure.Extensions;
using Infrastructure.Reponsitories.Abstractions;
using Infrastructure.Services.Abstractions;
using Infrastructure.Validations.Extend;
using MailKit;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infrastructure.Enums.ApiEnums;

namespace Infrastructure.Services.Base
{
    public class BaseService
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IHttpContextAccessor _contextAccessor;
        public readonly IUserContext _userContext;
        public BaseService(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor, IUserContext userContext)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
            _userContext = userContext;
        }
        public string GetClientIpAddress()
        {
            return _contextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
        public async Task CheckPermision(string functionCode, TypeAction type)
        {
            if (!string.IsNullOrEmpty(functionCode) && !CheckRoleExtension.CheckRoleByCode(_userContext.userClaims.access_key, functionCode, (int)type))
            {
                if (type == ApiEnums.TypeAction.VIEW)
                    throw new PermisionException(MessageErrorConstant.NOPERMISION_VIEW_MESSAGE);
                else if (type == ApiEnums.TypeAction.CREATE)
                    throw new PermisionException(MessageErrorConstant.NOPERMISION_CREATE_MESSAGE);
                else if (type == ApiEnums.TypeAction.UPDATE)
                    throw new PermisionException(MessageErrorConstant.NOPERMISION_UPDATE_MESSAGE);
                else if (type == ApiEnums.TypeAction.DELETED)
                    throw new PermisionException(MessageErrorConstant.NOPERMISION_DELETE_MESSAGE);
                else if (type == ApiEnums.TypeAction.IMPORT)
                    throw new PermisionException(MessageErrorConstant.NOPERMISION_ACTION_MESSAGE);
                else if (type == ApiEnums.TypeAction.EXPORT)
                    throw new PermisionException(MessageErrorConstant.NOPERMISION_ACTION_MESSAGE);
                else if (type == ApiEnums.TypeAction.PRINT)
                    throw new PermisionException(MessageErrorConstant.NOPERMISION_ACTION_MESSAGE);
                else if (type ==ApiEnums.TypeAction.EDIT_ANOTHER_USER)
                    throw new PermisionException(MessageErrorConstant.NOPERMISION_ACTION_MESSAGE);
            }
        }
    }
}
