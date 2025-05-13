using ExcelDataReader;
using Infrastructure.Exceptions.Extend;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commons
{
    public class ExcelHelper
    {
        public void validateFileExcel(IFormFile file)
        {
            var fileName = file.FileName.ToLower();
            long maxFileSize = 20 * 1024 * 1024; // 20 MB

            if (!fileName.EndsWith(".xlsx") && !fileName.EndsWith(".xls"))
            {
                throw new BadRequestException("ERROR_FILE_FORMAT");
            }
            else if (file.Length > maxFileSize || file.Length <= 0)
            {
                throw new BadRequestException("ERROR_FILE_LENGTH");
            }
        }

        public async Task<(DataTable, DataTable)> GetTableDataRegisterProjects(IFormFile file)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using var stream = new MemoryStream();

            await file.CopyToAsync(stream);
            stream.Position = 0;

            var reader = ExcelReaderFactory.CreateReader(stream);

            var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = false
                }
            });

            var table = dataSet.Tables[0];

            var totalRow = table.Rows.Count;

            var rowHeader = 2;
            var maxRow = 300;
            if (totalRow - rowHeader > maxRow)
            {
                throw new BadRequestException("ERROR_FILE_MAX_ROW");
            }

            //var maxColumn = 50;
            //if (maxColumn < table.Columns.Count - 1
            //    || rowHeader >= table.Rows.Count)
            //{
            //    throw new BadRequestException("ERROR_FILE_MAX_COLUMN");
            //}
            //for (int column = 1; column <= maxColumn; column++)
            //{
            //    var header = table.Rows[1][column].ToString();
            //    if (string.IsNullOrEmpty(header))
            //    {
            //        throw new BadRequestException("ERROR_FILE_FORMAT_CONTENT");
            //    }
            //}

            var tableMaster = dataSet.Tables[0];
            return (table, tableMaster);
        }
    }
}
