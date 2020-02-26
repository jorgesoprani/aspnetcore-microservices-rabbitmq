using MicroRabbitMQ.MVC.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroRabbitMQ.MVC.Services
{
    public interface ITransferService
    {
        Task Transfer(TransferDTO transferDTO);
    }
}
