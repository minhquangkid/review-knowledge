using Microsoft.AspNetCore.Mvc;
using Review.Model;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using static Review.Model.LogLine;
using LogLevel = Review.Model.LogLine.LogLevel;

namespace Review.Controllers
{
    [Route("/api/[controller]")]
    public class HomeController : Controller
    {
        public static readonly HttpClient client = new HttpClient();
        MyDbContext _context;
        public HomeController(MyDbContext context)
        {
            _context = context;
        }

        // https://exercism.org/tracks/csharp/exercises/logs-logs-logs/edit
        [HttpGet("work-with-enum-loglevel")]
        public async Task<IActionResult> WorkWithEnumLogLevel()
        {
            LogLevel a =  LogLine.ParseLogLevel("[INF]: File deleted");

            Console.WriteLine(a); //  sẽ ra INF

            //return Ok(a); // nhưng return api sẽ là 2

            return Ok(a.ToString()); // dùng cách này để chuyển về string là INF
        }


        [HttpGet("work-with-enum")]
        public async Task<IActionResult> WorkWithEnum()
        {
            Season  a = Season.Autumn; // a đang có kiểu là enum, ko phải string

            var test = $"Integral value of {a} is {(int)a}"; // print ra a sẽ là string, (int)a là ép kiểu về int

            var b = (Season)1; // ép kiểu int về enum Season
            Console.WriteLine(b);  // output: Summer

            var c = (Season)4;
            Console.WriteLine(c);  // output: 4

            return Ok(test);
        }

        //https://exercism.org/tracks/csharp/exercises/international-calling-connoisseur
        [HttpGet("work-with-dictionary")]
        public async Task<IActionResult> WorkWithDictionary()
        {
          var result =  DialingCodes.FindLongestCountryName(DialingCodes.GetExistingDictionary());

            return Ok(result);
        }

            //https://exercism.org/tracks/csharp/exercises/booking-up-for-beauty/edit
            [HttpGet("work-with-datetime")]
        public async Task<IActionResult> WorkWithDateTime()
        {
           var appointment1 = Appointment.Schedule("7/25/2019 13:45:00");

            var test2 = new DateTime(2019, 03, 29, 15, 0, 0);

            var d = $"You have an appointment on {test2.ToString("%M/%d/yyyy %h:mm:ss tt")}."; // dấu % để rút gọn tức là nếu là tháng 3 thì nó ghi 3 chứ ko phải 03

            DateTime dateNow = DateTime.Now;
            DateTime customDate = new DateTime(dateNow.Year, 9, 15);

            return Ok(d);
        }

        //https://exercism.org/tracks/csharp/exercises/elons-toys/edit
        [HttpGet("RemoteControlCar")]
        public async Task<IActionResult> RemoteControlCar()
        {
            var car = RemoteCar.Buy();
           var test =  car.BatteryDisplay();
            // => "Battery at 100%"

            return Ok(test);
        }

        //https://exercism.org/tracks/csharp/exercises/squeaky-clean/edit
        [HttpGet("SqueakyClean")]
        public async Task<IActionResult> SqueakyClean(string identifier)
        {
            identifier = identifier.Replace(' ', '_'); // câu 1

            StringBuilder strBuilder = new StringBuilder(identifier);
            for (int i = 0; i < strBuilder.Length; i++)
            {
                if (char.IsControl(strBuilder[i]))
                {
                    strBuilder = strBuilder.Replace(strBuilder[i].ToString(), "CTRL");  // câu 2
                }

                if (strBuilder[i] == '-' && strBuilder[i + 1] != '-')
                {
                    strBuilder = strBuilder.Remove(i, 1);
                    strBuilder[i] = char.ToUpper(strBuilder[i]);  // câu 3
                }
            }

            StringBuilder newString = new StringBuilder();

            for (int i = 0; i < strBuilder.Length; i++)
            {
                if (char.IsLetter(strBuilder[i]) || strBuilder[i] == '_') // câu 4
                {
                    newString.Append(strBuilder[i]);
                }
            }

            StringBuilder newString2 = new StringBuilder();

            for (int i = 0; i < newString.Length; i++)
            {
                if (newString [i]< 'α' || newString[i] > 'ω') // câu 5
                {
                    // Thêm ký tự vào chuỗi kết quả nếu không phải chữ cái Hy Lạp
                    newString2.Append(newString[i]);
                }
            }

            return Ok(newString2.ToString());

        }

        // xem https://exercism.org/tracks/csharp/exercises/secure-munchester-united/edit
        [HttpGet("get-type-class")]
        public async Task<IActionResult> TestGetTypeClass()
        {
            var spm = new SecurityPassMaker();
           var a = spm.GetDisplayName(new Manager());
            // => "Too Important for a Security Pass"

           var b = spm.GetDisplayName(new Physio());
            // => "The Physio"

           var c = spm.GetDisplayName(new Security());
            // => "Security Team Member Priority Personnel" 

           var d = spm.GetDisplayName(new SecurityJunior());
            // => "Security Junior Priority Personnel" // câu 2
            // => "Security Junior" // câu 3

            return Ok();
        }

        [HttpPost("add-customer")]
        public async Task<IActionResult> AddCustomer([FromBody] Customer payload)
        {
            _context.Customers.Add(payload);
            _context.SaveChanges();
            return Ok(true);
        }

        [HttpGet("get-fake-data")]
        public async Task<IActionResult> GetFakeAPI()
        {

            //HttpResponseMessage response;

            // using (var client = new HttpClient())
            // {
            //     response = await client.GetAsync("https://api.themoviedb.org/3/trending/all/week?api_key=3997fc9014661d7c2ce89c2bbea4b9f8&language=en-US");

            //     if(response.IsSuccessStatusCode)
            //     {
            //         var result = await response.Content.ReadAsStringAsync();

            //         return Ok(result);
            //     } else
            //     {
            //         return BadRequest(false);
            //     }
            // }

            HttpResponseMessage response = await client.GetAsync("https://api.themoviedb.org/3/trending/all/week?api_key=3997fc9014661d7c2ce89c2bbea4b9f8&language=en-US");

            if(response.IsSuccessStatusCode)
            {
               var content = await response.Content.ReadAsStringAsync();

                return Ok(content);
            } else
            {
                return BadRequest(false);
            }
        }

    }
}
