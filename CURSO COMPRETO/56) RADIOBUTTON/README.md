# RADIOBUTTON
Para utilizar o controle `RadioButton` em um aplicativo Windows Forms usando C#, siga os passos básicos abaixo. Os `RadioButtons` são usados para permitir que o usuário selecione uma opção única de um conjunto de opções mutuamente exclusivas.

## Passos para Adicionar e Usar RadioButton
### 1. **Adicionar RadioButton ao Formulário:**
Primeiro, adicione um ou mais controles `RadioButton` ao seu formulário no Visual Studio. Você pode encontrar o `RadioButton` na caixa de ferramentas do Visual Studio na seção "Common Controls".

- Arraste e solte o controle `RadioButton` do Visual Studio para o formulário.

### 2. **Configurar os RadioButtons:**
Após adicionar os controles `RadioButton` ao seu formulário, você pode configurar suas propriedades visualmente ou programaticamente.

- **Propriedades Visuais:** No Visual Studio, você pode ajustar propriedades como `Text` (texto exibido ao lado do botão), `Checked` (para definir se o botão está selecionado inicialmente), `Name` (nome do controle), entre outras.

- **Propriedades Programáticas:** Você também pode configurar as propriedades dos `RadioButtons` diretamente no código C#.

## Exemplo Programático:
Aqui está um exemplo básico de como adicionar e usar `RadioButtons` programaticamente em um formulário Windows Forms:

```csharp
using System;
using System.Windows.Forms;

public partial class Form1 : Form
{
    private RadioButton radioButton1;
    private RadioButton radioButton2;
    private Button button1;

    public Form1()
    {
        InitializeComponent();
        InitializeRadioButtons();
        InitializeButton();
    }

    private void InitializeRadioButtons()
    {
        radioButton1 = new RadioButton();
        radioButton1.Text = "Opção 1";
        radioButton1.Location = new System.Drawing.Point(50, 50);
        radioButton1.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
        this.Controls.Add(radioButton1);

        radioButton2 = new RadioButton();
        radioButton2.Text = "Opção 2";
        radioButton2.Location = new System.Drawing.Point(50, 80);
        radioButton2.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
        this.Controls.Add(radioButton2);
    }

    private void InitializeButton()
    {
        button1 = new Button();
        button1.Text = "Verificar Seleção";
        button1.Location = new System.Drawing.Point(50, 120);
        button1.Click += new EventHandler(button_Click);
        this.Controls.Add(button1);
    }

    private void radioButton_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton radioButton = sender as RadioButton;
        if (radioButton != null && radioButton.Checked)
        {
            MessageBox.Show("Opção selecionada: " + radioButton.Text);
        }
    }

    private void button_Click(object sender, EventArgs e)
    {
        if (radioButton1.Checked)
        {
            MessageBox.Show("Opção 1 está selecionada.");
        }
        else if (radioButton2.Checked)
        {
            MessageBox.Show("Opção 2 está selecionada.");
        }
        else
        {
            MessageBox.Show("Nenhuma opção selecionada.");
        }
    }
}
```

## Explicação do Exemplo:
- **InitializeRadioButtons():** Este método cria dois `RadioButtons` (`radioButton1` e `radioButton2`) e configura suas propriedades programaticamente, como `Text` e `Location`. Além disso, associa um evento `CheckedChanged` para cada botão, que é acionado quando o estado de seleção do botão muda.

- **InitializeButton():** Este método cria um botão (`button1`) e define seu texto e localização. Também associa um evento `Click` para o botão, que será usado para verificar qual opção de `RadioButton` está selecionada quando o botão for clicado.

- **radioButton_CheckedChanged():** Este é o manipulador de eventos `CheckedChanged`, que mostra uma mensagem de aviso quando um `RadioButton` é marcado (selecionado).

- **button_Click():** Este é o manipulador de eventos `Click` do botão, que verifica qual `RadioButton` está selecionado e exibe uma mensagem correspondente.

## Considerações Finais:
- **Personalização:** Você pode personalizar os `RadioButtons` ajustando suas propriedades como cor, fonte, tamanho e comportamento através do Visual Studio ou programaticamente.

- **Mutuamente Exclusivos:** Lembre-se de que os `RadioButtons` são projetados para serem mutuamente exclusivos por padrão em um mesmo contêiner (`Form`), o que significa que apenas um pode ser selecionado de cada vez.

Utilizando este guia, você pode adicionar e utilizar `RadioButtons` em seus formulários Windows Forms usando C# de maneira eficaz.