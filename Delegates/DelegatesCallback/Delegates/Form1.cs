namespace Delegates
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
                return;

            Emails email = new Emails();

            email.AddCallBack(Cadastrar);                   //registrando metodo no callback
            email.AddCallBack(NotificarPorEmail);           //registrando metodo no callback
            email.AddCallBack(AdicionarEmailParaPromocoes); //registrando metodo no callback

            email.Cadastrar(txtEmail.Text);
        }
        public void Cadastrar(string email) => txtAvisos.Items.Add($" O {email} foi adicionado a lista");
        public void NotificarPorEmail(string email) => txtAvisos.Items.Add($"Notificação enviada para {email}");
        public void AdicionarEmailParaPromocoes(string email) => txtAvisos.Items.Add($"O email {email} foi adicionado para receber promoções");
    }
    public class Emails
    {
        OnAddEmail _callBack;
        public void Cadastrar(string email)
        {
            _callBack(email);
        }
        public void AddCallBack(OnAddEmail callBack)
        {
            //adicionando os metodos.
            //ha a possibilidade de usar o -= para retirar o medoto.
            _callBack += callBack;
        }

        public delegate void OnAddEmail(string email);
    }
}