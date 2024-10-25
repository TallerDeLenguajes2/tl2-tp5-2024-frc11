using System.Collections.Generic;
using System.Linq;
using Models; // Importa el espacio de nombres Models donde están definidas tus clases

public interface IProductoRepository
{
    Producto FindById(int id);
    IEnumerable<Producto> FindAll();
    void Insert(Producto producto);
    void Update(int id, Producto producto);
    void Delete(int id);
}

public class ProductoRepository : IProductoRepository
{
    private readonly List<Producto> _productos;

    public ProductoRepository()
    {
        _productos = new List<Producto>();
    }

    public IEnumerable<Producto> FindAll()
    {
        return _productos;
    }

    public Producto FindById(int id)
    {
        return _productos.FirstOrDefault(p => p.IdProducto == id);
    }

    public void Insert(Producto producto)
    {
        _productos.Add(producto);
    }

    public void Update(int id, Producto producto)
    {
        var existingProduct = FindById(id);
        if (existingProduct != null)
        {
            existingProduct.Descripcion = producto.Descripcion;
            existingProduct.Precio = producto.Precio;
        }
    }

    public void Delete(int id)
    {
        var producto = FindById(id);
        if (producto != null)
        {
            _productos.Remove(producto);
        }
    }
}
