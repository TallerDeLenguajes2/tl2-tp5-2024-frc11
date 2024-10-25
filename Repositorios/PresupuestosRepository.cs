using System.Collections.Generic;
using System.Linq;
using Models; // Importa el espacio de nombres Models donde están definidas tus clases

public interface IPresupuestosRepository
{
    Presupuesto FindById(int id);
    IEnumerable<Presupuesto> FindAll();
    void Insert(Presupuesto presupuesto);
    void Delete(int id);
}

public class PresupuestosRepository : IPresupuestosRepository
{
    private readonly List<Presupuesto> _presupuestos;

    public PresupuestosRepository()
    {
        _presupuestos = new List<Presupuesto>();
    }

    public IEnumerable<Presupuesto> FindAll()
    {
        return _presupuestos;
    }

    public Presupuesto FindById(int id)
    {
        return _presupuestos.FirstOrDefault(p => p.IdPresupuesto == id);
    }

    public void Insert(Presupuesto presupuesto)
    {
        _presupuestos.Add(presupuesto);
    }

    public void Delete(int id)
    {
        var presupuesto = FindById(id);
        if (presupuesto != null)
        {
            _presupuestos.Remove(presupuesto);
        }
    }
}
