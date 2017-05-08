using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.LocalDB.ViewModel;

namespace XF.LocalDB.View.Aluno
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlunoView : ContentPage
    {
        AlunoViewModel vmAluno;
        int alunoID;
        public AlunoView()
        {
            vmAluno = new AlunoViewModel();
            BindingContext = vmAluno;

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            vmAluno = new AlunoViewModel();
            BindingContext = vmAluno;

            base.OnAppearing();

            MessagingCenter.Subscribe<AlunoViewModel>(vmAluno, "NovoAluno", (msg) =>
              {
                  Navigation.PushAsync(new NovoView());
              });

            MessagingCenter.Subscribe<AlunoViewModel>(vmAluno, "AlunoSelecionado", (msg) =>
            {
                Navigation.PushAsync(new NovoView(msg.Id));
            });

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<AlunoViewModel>(vmAluno, "NovoAluno");
            MessagingCenter.Unsubscribe<AlunoViewModel>(vmAluno, "AlunoSelecionado");
        }

    }
}
