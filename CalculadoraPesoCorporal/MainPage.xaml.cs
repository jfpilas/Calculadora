using Microsoft.Maui.Controls;

namespace CalculadoraPesoCorporal;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    
   
    
    private void OnCalcularClicked(object sender, EventArgs e)
    {
        try
        {
            
            if (double.TryParse(txtAltura.Text, out double alturaCm) && double.TryParse(txtPeso.Text, out double pesoKg))
            {
                
                double alturaM = alturaCm / 100;

                
                double imc = pesoKg / (alturaM * alturaM);

                string categoria ;
                if (imc < 18.5)
                {
                    categoria = " Bajo peso";
                }
                else if (imc >= 18.5 && imc < 24.9)
                {
                    categoria = " Peso normal";
                }
                else if (imc >= 25 && imc < 29.9)
                {
                    categoria = " Sobrepeso";
                }
                else
                {
                    categoria = " Obesidad";
                }



                DisplayAlert("Resultado", $"Tu IMC es: {imc:0.00}\n Categoría:{categoria}", "OK");
            }
            else
            {
                
                DisplayAlert("Error", "Por favor ingrese valores válidos para la altura y el peso.", "OK");
            }
        }
        catch (Exception ex)
        {
            
            DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
        }
    }

    
    private void OnLimpiarClicked(object sender, EventArgs e)
    {
        
        txtAltura.Text = string.Empty;
        txtPeso.Text = string.Empty;
        
    }

   
    private void OnSalirClicked(object sender, EventArgs e)
    {
        
        Application.Current.Quit();
    }

    private void OnPesoChanged(object sender, TextChangedEventArgs e)
    {
        txtPeso.Text = e.NewTextValue.Replace('.',',');
    }
}
