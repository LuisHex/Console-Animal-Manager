using CrudExample.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CrudExample.Repositories
{
    //void SaveTicket(Ticket ticket);
    //List<Ticket> GetTickets();
    //Ticket GetTicketById(int id);
    //void UpdateTicket(Ticket updatedTicket);
    //void DeleteTicket(int id);

    public interface IAnimalRepository
    {
        void SaveAnimal(Animal animal);
        List<Animal> GetAnimals();
        Animal GetAnimalById(int id);
        void UpdateAnimal(Animal updatedAnimal);
        void DeleteAnimal(int id);
        void AddDataTest();
        void message(string message);
        void DeleteAllAnimals();
    }

}
