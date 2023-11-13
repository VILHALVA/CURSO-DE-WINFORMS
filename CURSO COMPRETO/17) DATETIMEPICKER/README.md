# DATETIMEPICKER
O controle `DateTimePicker` em Windows Forms é usado para permitir que os usuários selecionem uma data e uma hora. Ele fornece uma interface amigável para entrada e exibição de valores de data e hora.

Aqui está um exemplo básico de como usar o `DateTimePicker` em um formulário Windows Forms:

```csharp
using System;
using System.Windows.Forms;

namespace MeuProjetoWinForms
{
    public partial class MeuFormulario : Form
    {
        private DateTimePicker dateTimePicker1;

        public MeuFormulario()
        {
            InitializeComponent();

            // Criando um DateTimePicker
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker1.Location = new System.Drawing.Point(20, 20);
            this.Controls.Add(dateTimePicker1);

            // Associando um manipulador de eventos ao evento ValueChanged
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;

            // Exibindo a data e a hora atuais
            dateTimePicker1.Value = DateTime.Now;
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Manipulador de eventos para tratar a mudança no valor do DateTimePicker
            DateTimePicker dateTimePicker = (DateTimePicker)sender;

            MessageBox.Show("Data e Hora selecionadas: " + dateTimePicker.Value.ToString());
        }
    }
}
```

Neste exemplo:

- Criamos um `DateTimePicker` chamado `dateTimePicker1`.
- Associamos um manipulador de eventos ao evento `ValueChanged` para tratar a mudança no valor do `DateTimePicker`.
- Exibimos a data e a hora atuais no `DateTimePicker`.

Principais propriedades do `DateTimePicker`:

- **Value:** Obtém ou define a data e a hora selecionadas.
- **Format:** Define o formato de exibição da data e hora (`Short`, `Long`, `Time`, etc.).
- **ShowUpDown:** Indica se a parte do controle que exibe a hora é exibida (quando `true`) ou não (quando `false`).
- **MinDate e MaxDate:** Limitam a faixa de datas permitidas.

Você pode personalizar o controle de acordo com suas necessidades específicas. O `DateTimePicker` é especialmente útil quando você precisa que os usuários selecionem datas ou horas de forma fácil e intuitiva.