﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RestAPI2.Helper
{
    public static class IEnumerableExtensions
    {

        public static IEnumerable<ExpandoObject>ShapeData<TSource>(this IEnumerable<TSource>source,string fields)
        {
            if (source==null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var expandoObjectList = new List<ExpandoObject>();
            var propertyInfoList = new List<PropertyInfo>();

            if(string.IsNullOrWhiteSpace(fields))
            {
                var propertyInfos = typeof(TSource)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance);

                propertyInfoList.AddRange(propertyInfos);
             }

                else
                {
                    var fieldAfterSplit = fields.Split(",");
                    foreach (var field in fieldAfterSplit)
                    {
                        var propertyName = field.Trim();

                        var propertyInfo = typeof(TSource).GetProperty(
                            propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                        if (propertyInfo==null)
                        {
                            throw new Exception($"propperty{propertyName}wasn't found on " +
                                $"{typeof(TSource)}");
                        }

                        propertyInfoList.Add(propertyInfo);


                    }
                }

                foreach (TSource sourceObject in source)
                {
                    var dataShapedObject = new ExpandoObject();


                    foreach (var propertyInfo in propertyInfoList)
                    {
                        var propertyValue = propertyInfo.GetValue(sourceObject);

                        ((IDictionary<string, object>)dataShapedObject).Add(propertyInfo.Name, propertyValue);
                    }

                    expandoObjectList.Add(dataShapedObject);
                }

                return expandoObjectList;
            }
        }
    }

