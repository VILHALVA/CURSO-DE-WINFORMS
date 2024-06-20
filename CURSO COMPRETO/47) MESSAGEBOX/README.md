# MESSAGEBOX
A classe `MessageBox` em C# é utilizada para exibir uma caixa de diálogo pré-definida que pode mostrar mensagens simples, perguntas ao usuário ou avisos. É uma forma eficaz de interagir com o usuário em aplicações Windows Forms. Abaixo estão alguns exemplos de como utilizar a `MessageBox` para diferentes finalidades:

## Exemplos de Uso da `MessageBox`
1. **Exibir uma mensagem informativa:**

   Para mostrar uma mensagem simples ao usuário:

   ```csharp
   MessageBox.Show("Esta é uma mensagem informativa.", "Informação");
   ```

   Neste exemplo:
   - `"Esta é uma mensagem informativa."` é o texto exibido na caixa de mensagem.
   - `"Informação"` é o título da janela da mensagem.

2. **Perguntar ao usuário e obter resposta:**

   Para solicitar uma decisão do usuário (sim ou não):

   ```csharp
   DialogResult result = MessageBox.Show("Deseja salvar as alterações?", "Salvar Alterações", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

   if (result == DialogResult.Yes)
   {
       // Código para salvar as alterações
   }
   else
   {
       // Código para descartar as alterações
   }
   ```

   Neste exemplo:
   - `"Deseja salvar as alterações?"` é a pergunta exibida.
   - `"Salvar Alterações"` é o título da janela da mensagem.
   - `MessageBoxButtons.YesNo` especifica os botões "Sim" e "Não".
   - `MessageBoxIcon.Question` exibe um ícone de interrogação na caixa de mensagem.

3. **Exibir uma mensagem de erro:**

   Para alertar o usuário sobre um erro:

   ```csharp
   MessageBox.Show("Ocorreu um erro ao carregar o arquivo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
   ```

   Neste exemplo:
   - `"Ocorreu um erro ao carregar o arquivo."` é a mensagem de erro exibida.
   - `"Erro"` é o título da janela da mensagem.
   - `MessageBoxButtons.OK` especifica apenas o botão "OK".
   - `MessageBoxIcon.Error` exibe um ícone de erro na caixa de mensagem.

4. **Personalizar o botão padrão:**

   É possível definir qual botão será o padrão na caixa de mensagem (o botão que é acionado quando o usuário pressiona `Enter`):

   ```csharp
   DialogResult result = MessageBox.Show("Deseja continuar?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

   if (result == DialogResult.Yes)
   {
       // Código para continuar
   }
   else if (result == DialogResult.No)
   {
       // Código para cancelar
   }
   ```

   Neste exemplo:
   - `MessageBoxDefaultButton.Button2` define o segundo botão (`No`) como padrão.

## Parâmetros da `MessageBox`
- **Mensagem (string):** Texto exibido na caixa de mensagem.
- **Título (string):** Título da janela da mensagem.
- **Botões (`MessageBoxButtons`):** Especifica os botões exibidos na caixa de mensagem (`OK`, `OKCancel`, `YesNo`, etc.).
- **Ícone (`MessageBoxIcon`):** Especifica o ícone exibido na caixa de mensagem (`None`, `Error`, `Warning`, `Question`, `Information`).
- **Botão padrão (`MessageBoxDefaultButton`):** Define qual botão será o padrão na caixa de mensagem.

## Nota Importante
- **DialogResult:** O método `MessageBox.Show()` retorna um valor do tipo `DialogResult`, que indica qual botão o usuário pressionou na caixa de mensagem (`OK`, `Cancel`, `Yes`, `No`, etc.).

A classe `MessageBox` é muito útil para interações básicas com o usuário em aplicações Windows Forms, fornecendo uma maneira padronizada e fácil de exibir mensagens, solicitar confirmações e alertar sobre problemas.