using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerUI.Services
{
    /// <summary>
    /// Represents the response from the backend APIs.
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// Gets or sets the response from Backend API 1.
        /// </summary>
        public string? Api1Response { get; set; }

        /// <summary>
        /// Gets or sets the response from Backend API 2.
        /// </summary>
        public string? Api2Response { get; set; }
    }
}
