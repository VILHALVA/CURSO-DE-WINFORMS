# TABORDER
O `TabOrder` (ordem de tabulação) em Windows Forms é a sequência na qual os controles recebem o foco quando o usuário pressiona a tecla Tab. A ordem de tabulação é importante para garantir uma navegação eficiente e lógica pelos controles de um formulário.

## Definindo a Ordem de Tabulação
Cada controle no Windows Forms possui uma propriedade chamada `TabIndex`. O valor de `TabIndex` define a posição do controle na ordem de tabulação. Os controles são focados na ordem crescente dos valores de `TabIndex`.

## Exemplo de Configuração de TabOrder
Aqui está um exemplo simples de como configurar a ordem de tabulação para alguns controles em um formulário:

```csharp
using System;
using System.Windows.Forms;

public class TabOrderForm : Form
{
    public TabOrderForm()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        // Criação dos controles
        TextBox textBox1 = new TextBox { Location = new Point(20, 20), TabIndex = 0 };
        TextBox textBox2 = new TextBox { Location = new Point(20, 60), TabIndex = 1 };
        Button button1 = new Button { Location = new Point(20, 100), Text = "Botão 1", TabIndex = 2 };
        Button button2 = new Button { Location = new Point(20, 140), Text = "Botão 2", TabIndex = 3 };

        // Adição dos controles ao formulário
        this.Controls.Add(textBox1);
        this.Controls.Add(textBox2);
        this.Controls.Add(button1);
        this.Controls.Add(button2);

        // Configurações do formulário
        this.Text = "Exemplo de TabOrder";
        this.Size = new Size(300, 300);
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new TabOrderForm());
    }
}
```

## Explicação do Código
1. **Criação dos Controles**: São criados dois `TextBox` e dois `Button`.

2. **Configuração do TabIndex**:
   - `textBox1` recebe `TabIndex = 0`, então será o primeiro controle a receber o foco.
   - `textBox2` recebe `TabIndex = 1`, então será o segundo.
   - `button1` recebe `TabIndex = 2`, então será o terceiro.
   - `button2` recebe `TabIndex = 3`, então será o quarto.

3. **Adição dos Controles ao Formulário**: Os controles são adicionados ao formulário.

4. **Configurações do Formulário**: O título do formulário é definido como "Exemplo de TabOrder" e o tamanho do formulário é ajustado.

## Considerações Importantes
- **TabStop**: A propriedade `TabStop` determina se um controle pode ser focado usando a tecla Tab. Se `TabStop` for definido como `false`, o controle será ignorado na ordem de tabulação.
- **Configuração Visual**: No designer do Visual Studio, você pode definir a ordem de tabulação visualmente clicando com o botão direito do mouse no formulário e selecionando "Tab Order". Isso permite que você clique nos controles na ordem desejada, definindo automaticamente os valores de `TabIndex`.

## Conclusão
Definir a ordem de tabulação é essencial para criar interfaces de usuário acessíveis e fáceis de navegar. Usar corretamente as propriedades `TabIndex` e `TabStop` permite controlar a sequência em que os controles recebem o foco, melhorando a experiência do usuário.