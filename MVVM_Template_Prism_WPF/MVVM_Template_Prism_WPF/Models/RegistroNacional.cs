using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Template_Prism_WPF.Models
{
    public class RegistroNacional : BindableBase
    {
		private static RegistroNacional instance = null;

		private RegistroNacional()
		{
			listaPersonas = new ObservableCollection<Persona>();
			listaCiudades = new ObservableCollection<Ciudad>();
			LoadData();
		}

		public static RegistroNacional Instance
		{
			get
			{
				if (instance is null)
				{
					instance = new RegistroNacional();
				}
				return instance;
			}
		}


		private void LoadData()
		{
			listaCiudades.Add(new Ciudad() { ID = "0", Nombre = "Tumbes", Area=1500.3f });
			listaCiudades.Add(new Ciudad() { ID = "1", Nombre = "Lima", Area = 12500.9f });
			listaCiudades.Add(new Ciudad() { ID = "2", Nombre = "Piura", Area =7520.6f });
			listaCiudades.Add(new Ciudad() { ID = "3", Nombre = "Chiclayo", Area = 6410.5f });
			listaCiudades.Add(new Ciudad() { ID = "4", Nombre = "Trujillo", Area = 5899.4f });



			listaPersonas.Add(new Persona() { DNI = "10", Nombre = "Javier", Apellido = "Nole", Ciudad = ListaCiudades[0], Sueldo=5423});
			listaPersonas.Add(new Persona() { DNI = "11", Nombre = "Lucia", Apellido = "Sandoval", Ciudad = ListaCiudades[1], Sueldo = 5543 });
			listaPersonas.Add(new Persona() { DNI = "12", Nombre = "Estefano", Apellido = "Acuila", Ciudad = ListaCiudades[2], Sueldo = 1546 });
			listaPersonas.Add(new Persona() { DNI = "13", Nombre = "Santiago", Apellido = "Poresa", Ciudad = ListaCiudades[4], Sueldo = 2395 });
			listaPersonas.Add(new Persona() { DNI = "14", Nombre = "Maria", Apellido = "Garcia", Ciudad = ListaCiudades[3], Sueldo = 143 });
			listaPersonas.Add(new Persona() { DNI = "15", Nombre = "Pepe", Apellido = "Uyunke", Ciudad = ListaCiudades[4], Sueldo = 7120});
			listaPersonas.Add(new Persona() { DNI = "16", Nombre = "Javier", Apellido = "Nole", Ciudad = ListaCiudades[4], Sueldo = 1235 });
			listaPersonas.Add(new Persona() { DNI = "17", Nombre = "Lucia", Apellido = "Sandoval", Ciudad = ListaCiudades[4], Sueldo = 7421 });
			listaPersonas.Add(new Persona() { DNI = "18", Nombre = "Estefano", Apellido = "Acuila", Ciudad = ListaCiudades[1], Sueldo = 6321 });
			listaPersonas.Add(new Persona() { DNI = "19", Nombre = "Santiago", Apellido = "Poresa", Ciudad = ListaCiudades[1], Sueldo = 1800 });
			listaPersonas.Add(new Persona() { DNI = "20", Nombre = "Maria", Apellido = "Garcia", Ciudad = ListaCiudades[2], Sueldo = 1423 });
			listaPersonas.Add(new Persona() { DNI = "21", Nombre = "Pepe", Apellido = "Uyunke", Ciudad = ListaCiudades[2], Sueldo = 4123 });
			listaPersonas.Add(new Persona() { DNI = "22", Nombre = "Javier", Apellido = "Nole", Ciudad = ListaCiudades[3], Sueldo = 7412 });
			listaPersonas.Add(new Persona() { DNI = "23", Nombre = "Lucia", Apellido = "Sandoval", Ciudad = ListaCiudades[4], Sueldo = 1896 });
			listaPersonas.Add(new Persona() { DNI = "24", Nombre = "Estefano", Apellido = "Acuila", Ciudad = ListaCiudades[2], Sueldo = 1230 });
			listaPersonas.Add(new Persona() { DNI = "25", Nombre = "Santiago", Apellido = "Poresa", Ciudad = ListaCiudades[0], Sueldo = 741 });
			listaPersonas.Add(new Persona() { DNI = "26", Nombre = "Maria", Apellido = "Garcia", Ciudad = ListaCiudades[1], Sueldo = 7123 });
			listaPersonas.Add(new Persona() { DNI = "27", Nombre = "Pepe", Apellido = "Uyunke", Ciudad = ListaCiudades[2], Sueldo = 575 });
			listaPersonas.Add(new Persona() { DNI = "28", Nombre = "Arthur", Apellido="Valladares", Ciudad = ListaCiudades[3], Sueldo = 8742 });

		}

        #region Listas
        private ObservableCollection<Persona> listaPersonas;

		public ObservableCollection<Persona> ListaPersonas
		{
			get { return listaPersonas; }
			set { SetProperty(ref listaPersonas, value); }
		}


		private ObservableCollection<Ciudad> listaCiudades;

		public ObservableCollection<Ciudad> ListaCiudades
		{
			get { return listaCiudades; }
			set { SetProperty(ref listaCiudades, value); }
		}


		#endregion

	}
}
