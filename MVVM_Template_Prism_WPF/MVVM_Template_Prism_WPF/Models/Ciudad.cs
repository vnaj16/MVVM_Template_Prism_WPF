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
    //Ciudad: ID, Nombre, Área, Habitantes
    public class Ciudad : BindableBase
    {
		private string id;

		[Required(ErrorMessage ="El campo ID debe ser completado")]
		[StringLength(4,ErrorMessage = "El size minimo del ID es 2 y el maximo 4", MinimumLength =2)]
		public string ID
		{
			get { return id; }
			set
			{
				SetProperty(ref id, value);
			}
		}


		private string nombre;

		[StringLength(50,MinimumLength =3)]
		public string Nombre
		{
			get { return nombre; }
			set
			{
				SetProperty(ref nombre, value);
			}
		}

		private float area;

		public float Area
		{
			get { return area; }
			set
			{
				SetProperty(ref area, value);
			}
		}

		private ObservableCollection<Persona> habitantes = new ObservableCollection<Persona>();

		public ObservableCollection<Persona> Habitantes
		{
			get { return habitantes; }
			set { SetProperty(ref habitantes, value);}
		}


		public override string ToString()
		{
			return ID + " - " + Nombre;
		}

		public Ciudad Clone()
		{
			return (Ciudad)this.MemberwiseClone();
		}
	}
}
