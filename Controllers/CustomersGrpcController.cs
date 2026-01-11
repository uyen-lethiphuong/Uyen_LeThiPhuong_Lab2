using Grpc.Net.Client;
using GrpcCustomersService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Channels;
using Uyen_LeThiPhuong_Lab2.Models;

namespace Nume_Pren_Lab2.Controllers
{
    public class CustomersGrpcController : Controller
    {
        private readonly GrpcChannel channel;
    public CustomersGrpcController()
    {
   channel = GrpcChannel.ForAddress("https://localhost:7159");
    }
    [HttpGet]
    public IActionResult Index()
    {
        var client = new CustomerService.CustomerServiceClient(channel);


        CustomerList cust = client.GetAll(new Empty());

        return View(cust);

    }


    public IActionResult Create()
    {
        return View();
    }

        [HttpPost]
        public IActionResult Create(Uyen_LeThiPhuong_Lab2.Models.Customer customer)
        {
            if (ModelState.IsValid)
            {
                var client = new CustomerService.CustomerServiceClient(channel);

                // --- SỬA ĐOẠN NÀY ---
                // Tạo một đối tượng Customer của gRPC và copy dữ liệu từ Model sang
                var grpcCustomer = new GrpcCustomersService.Customer
                {
                    CustomerId = customer.CustomerId,
                    Name = customer.Name,
                    Adress = customer.Adress,
                    Birthdate = customer.BirthDate.ToString("yyyy-MM-dd") // Chuyển ngày tháng thành chuỗi
                };

                // Truyền đối tượng gRPC vừa tạo vào hàm Insert
                var createdCustomer = client.Insert(grpcCustomer);
                // --------------------

                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // --- CODE TỪ TRANG 10 & 11 (DELETE) ---
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = new CustomerService.CustomerServiceClient(channel);
            GrpcCustomersService.Customer customer = client.Get(new CustomerId() { Id = (int)id });

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var client = new CustomerService.CustomerServiceClient(channel);
            Empty response = client.Delete(new CustomerId()
            {
                Id = id
            });

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var client = new CustomerService.CustomerServiceClient(channel);

            // --- Bỏ Try/Catch để xem lỗi hiện ra màn hình là gì ---
            // try {
            var customer = client.Get(new CustomerId { Id = (int)id });
            var model = new Uyen_LeThiPhuong_Lab2.Models.Customer
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Adress = customer.Adress,
                BirthDate = string.IsNullOrEmpty(customer.Birthdate)
            ? DateTime.Now
            : DateTime.Parse(customer.Birthdate)
            };
            return View(model);
            // } catch (Exception) { return NotFound(); }
        
        }

        [HttpPost]
        public IActionResult Edit(Uyen_LeThiPhuong_Lab2.Models.Customer customer)
        {
            if (ModelState.IsValid)
            {
                var client = new CustomerService.CustomerServiceClient(channel);

                // Tạo object gRPC
                var grpcCustomer = new GrpcCustomersService.Customer
                {
                    CustomerId = customer.CustomerId,
                    Name = customer.Name,
                    Adress = customer.Adress,
                    Birthdate = customer.BirthDate.ToString("yyyy-MM-dd")
                };

                // Gọi hàm Update bên Service
                client.Update(grpcCustomer);

                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
    }
}
