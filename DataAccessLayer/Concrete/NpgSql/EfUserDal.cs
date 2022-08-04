﻿using CoreLayer.Entities;
using DataAccessLayer.Abtract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.NpgSql
{
   public class EfUserDal : EfEntityRepositoryBase<User>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (ERPContext context = new ERPContext(new DbContextOptions<ERPContext>()))
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
