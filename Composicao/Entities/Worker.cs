using System.Collections.Generic;
using Composicao.Entities.Enums;

namespace Composicao.Entities
{
    internal class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Departament Departament { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();


        public Worker()
        {
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Departament departament)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Departament = departament;
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        } //adiciona contract na list

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }//remove contract na list

        public double Income(int year, int month)
        {
            double sum = BaseSalary; //salario base e nao 0, pq eles ja tem um valor inicial

            foreach (HourContract contract in Contracts)
            {
                if (contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();//acrescento nessa soma apenas os q sao do ano e do mes solicitado
                }
            }
            return sum;
        }

    }
}
