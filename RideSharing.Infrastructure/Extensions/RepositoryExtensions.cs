﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RideSharing.Infrastructure.Extensions
{
    internal static class RepositoryExtensions
    {

        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
            where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }
    }
}