using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Template_Prism_WPF.Models
{
    /*
     Persona: DNI, Nombre, Apellido, Fecha Nac, sueldo, Id_ciudad
         */
    public class Persona : BindableBase
    {
		private string dni;

		[Required(ErrorMessage = "El campo DNI debe ser completado")]
		[StringLength(4, ErrorMessage = "El size minimo del DNI es 2 y el maximo 4", MinimumLength = 2)]
		public string DNI
		{
			get { return dni; }
			set
			{
				SetProperty(ref dni, value);
			}
		}


		private string nombre;

		[StringLength(50, MinimumLength = 3)]
		public string Nombre
		{
			get { return nombre; }
			set
			{
				SetProperty(ref nombre, value);
			}
		}


		private string apellido;

		[StringLength(50, MinimumLength = 3)]
		public string Apellido
		{
			get { return apellido; }
			set
			{
				SetProperty(ref apellido, value);
			}
		}


		private DateTime fechaNacimiento = DateTime.Now;

		public DateTime FechaNacimiento
		{
			get { return fechaNacimiento; }
			set { SetProperty(ref fechaNacimiento, value); }
		}


		private float sueldo;

		[Range(1000,9000, ErrorMessage ="El sueldo debe estar entre 1000 y 9000")]
		public float Sueldo
		{
			get { return sueldo; }
			set { SetProperty(ref sueldo, value); }
		}

		public override string ToString()
		{
			return nombre + " " + apellido;
		}



		private Ciudad ciudad;

		public Ciudad Ciudad
		{
			get { return ciudad; }
			set {
				SetProperty(ref ciudad, value);
				if(!(value is null))
				ciudad.Habitantes.Add(this);
			}
		}

		private ObservableCollection<Telefono> telefonos = new ObservableCollection<Telefono>() { new Telefono() { Numero="123"}, new Telefono() { Numero="789"} };

		public ObservableCollection<Telefono> Telefonos
		{
			get { return telefonos; }
			set { SetProperty(ref telefonos, value); }
		}

		public Persona Clone()
		{
			return (Persona)this.MemberwiseClone();
		}

	}
}
