using System.Collections.Generic;
using DentalSystem.Entities.Models;

namespace DentalSystem.Contract.Repositories
{
    public interface IVisitRepository
    {
        int AddVisit(Visit visit);
       void EndVisit(Visit visit);
    }
}