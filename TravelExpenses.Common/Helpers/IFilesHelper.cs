using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TravelExpenses.Common.Helpers
{
    public interface IFilesHelper
    {
        byte[] ReadFully(Stream input);
    }

}
