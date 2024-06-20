# FONTDIALOG
O `FontDialog` em aplicações Windows Forms em C# permite aos usuários selecionar uma fonte para aplicar a um texto em um controle, como um `Label`, `TextBox` ou qualquer outro controle de texto. É uma ferramenta útil para oferecer personalização visual aos usuários, permitindo que eles escolham o estilo da fonte, tamanho, cor, entre outras propriedades.

## Exemplo de Uso do FontDialog
Aqui está um exemplo básico de como utilizar o `FontDialog` em uma aplicação Windows Forms:

```csharp
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExemploFontDialog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelecionarFonte_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog1 = new FontDialog();

            // Configurações do FontDialog
            fontDialog1.Font = label1.Font; // Define a fonte inicial como a fonte atual do label
            fontDialog1.Color = label1.ForeColor; // Define a cor inicial como a cor atual do texto do label

            // Exibir o diálogo
            DialogResult result = fontDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Atualizar a fonte do label com a fonte selecionada pelo usuário
                label1.Font = fontDialog1.Font;

                // Atualizar a cor do texto do label com a cor selecionada pelo usuário
                label1.ForeColor = fontDialog1.Color;
            }
        }
    }
}
```

## Explicação do Código
1. **Inicialização do `FontDialog`**:
   - Criamos uma instância do `FontDialog` chamada `fontDialog1`.

2. **Configurações do `FontDialog`**:
   - `Font`: Define a fonte inicial do `FontDialog`. No exemplo, definimos a fonte inicial como a fonte atual do `Label` (`label1.Font`).
   - `Color`: Define a cor inicial do texto do `FontDialog`. Aqui, definimos a cor inicial como a cor atual do texto do `Label` (`label1.ForeColor`).

3. **Exibição do Diálogo**:
   - Chamamos o método `ShowDialog()` para exibir o diálogo e aguardamos a interação do usuário.

4. **Processamento do Resultado**:
   - Verificamos se o usuário pressionou o botão "OK" (`DialogResult.OK`).
   - Se o usuário selecionou uma fonte e confirmou, atualizamos a propriedade `Font` do `Label` (`label1.Font`) com a fonte selecionada pelo usuário através do `FontDialog`.
   - Também atualizamos a cor do texto do `Label` (`label1.ForeColor`) com a cor selecionada pelo usuário através do `FontDialog`.

