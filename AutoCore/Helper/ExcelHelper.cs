using AutoMapper;
using LinqToExcel;
using System.Collections.Generic;
using System.Linq;

namespace AutoCore
{
    public static class ExcelHelper
    {
        public static IList<UserDto> UseTheProvidedData(string path, string sheetName)
        {

            var excelFile = new ExcelQueryFactory(path);
            var dataContext = from a in excelFile.Worksheet<User>(sheetName) select a;

            var dataCopy = Mapper.Map<IList<User>>(dataContext);

            return dataCopy.Select(data =>
            {
                return new UserDto
                {
                    Username = data.Username,
                    Password = data.Password
                };
            }).ToList();

        }
    }
}
