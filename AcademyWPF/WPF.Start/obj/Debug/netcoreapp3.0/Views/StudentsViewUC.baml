   M S B A M L   `   `   `  ����D  @WPF.Start, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPF.Start.ViewsWPF.Start.Views  5      1clr-namespace:WPF.Start.RulesWPF.Start.Rules  5      $    WPF.Start.Views.StudentsViewUC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      )localclr-namespace:WPF.Start.Views  5      %rclr-namespace:WPF.Start.Rules  5      .��5      � ���	#FFFFD4FD  � ColumnDefinitions  5   
   �� 5      $	��400 �6   �� 5      $��* �6   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $��70 �6    �� 5      $	��280 �6    �� 5      $��* �6    .+�5      � $��0��6   .+�5      �� $��Center=�6   $��LET'S HANDLE STUDENTS!!��69   $
��Wrap=�6X   $��Center=�6l   $	��270��6�   $��22(�6�   �� 5      $��Center=�6   $1��+- what do you want to do with them today? -��69   $
��Wrap=�6l   $	��Top=�6�   $	��320��6�   $��16(�6�   $��0,42,0,0q�6�   5      � 5       $��1��6   $��0,10,0,0q�6    .+�5"      �� $
��Left=�6   $��26��65   $��	98,17,0,0q�6A    �� TextWrapping$
 Wrap=�6T   $	��Top=�6h   $	��268��6�      errorTemplate =� ErrorTemplate# [  5#      .��6T   ��5$      �� 5%       �� Path$
 Name�6"    �� ValidatesOnDataErrors$
 True��6.    �� UpdateSourceTrigger$ PropertyChanged=�6K    �� ValidationRules 5&      $   WPF.Start.Rules.ValidationName  5'   "   5)      .��5*   $   5+      �� 5-      $
��Left=�6   $��26��65   $��	98,49,0,0q�6A   $
 Wrap=�6T   $	��Top=�6h   $	��268��6�   # [  5.      .��6U   ��5/      �� 50      $ 	LastName1�6"   $
 True��63   $ PropertyChanged=�6P    51        52   "   54      .��55   $   56      �� 58      $
��Left=�6   $��26��65   $��	98,80,0,0q�6A   $
 Wrap=�6T   $	��Top=�6h   $	��268��6�   # [  59      .��6T   ��5:      �� 5;      $ 	LastName2�6"   $
 True��63   $ PropertyChanged=�6P    5<        5=   "   5?      .��5@   $   5A      �� 5C      $
��Left=�6   $��26��65   $��
98,111,0,0q�6A   $
 Wrap=�6U   $	��Top=�6i   $	��268��6�   # [  5D      .��6T   ��5E      �� 5F      $	 Dni�6"   $
 True��6-   $ PropertyChanged=�6J    5G        5H   "   5J      .��5K   $   5L      �� 5N      $
��Left=�6   $��26��65   $��
98,142,0,0q�6A   $
 Wrap=�6U   $	��Top=�6i   $	��268��6�   # [  5O      .��6T   ��5P      �� 5Q      $ Chair�6"   $
 True��6/   $ PropertyChanged=�6L    5R      %   WPF.Start.Rules.ValidationChair  5S   "   5U      .��5V   $   5W      �� 5Y      $
��Left=�6   $��
98,221,0,0q�66    �� DisplayMemberPath$
 Name��6s   $	��Top=�6�   $	��173��6�   $��26��6�   ��6J   �� *SubjectsToSelect+	 �� SelectedValue	 6�   �� *SubjectSelected+
 �� Mode$
 TwoWay=�6�   �� 5[      $
��Left=�6   $��	22,22,0,0q�67   $��Name:��6J   $
��Wrap=�6W   $	��Top=�6k   $��60��6�   $��26��6�    �� TextAlignment$ Right=�6�   $��14(�6�   �� 5\      $
��Left=�6   $��	10,52,0,0q�67   $��	LastName:��6J   $
��Wrap=�6[   $	��Top=�6o   $��72��6�   $��20��6�   $ Right=�6�   $��14(�6�   �� 5]      $
��Left=�6   $��	10,82,0,0q�67   $��
LastName2:��6J   $
��Wrap=�6\   $	��Top=�6p   $��72��6�   $��22��6�   $ Right=�6�   $��14(�6�   �� 5^      $
��Left=�6   $��
25,114,0,0q�67   $
��Dni:��6K   $
��Wrap=�6W   $	��Top=�6k   $��60��6�   $��20��6�   $ Right=�6�   $��14(�6�   �� 5_      $
��Left=�6   $��
25,145,0,0q�67   $��Chair:��6K   $
��Wrap=�6Y   $	��Top=�6m   $��60��6�   $��20��6�   $ Right=�6�   $��14(�6�   �� 5`      $
��Left=�6   $��
25,221,0,0q�67   $��Subject:��6K   $
��Wrap=�6[   $	��Top=�6o   $��60��6�   $��20��6�   $ Right=�6�   $��14(�6�   �� 5b      $��Register��69   $
��Left=�6L   $��
98,173,0,0q�6g   $	��Top=�6{   ���	#FFE800FF$��32��6�   $	��134��6�   ��6   �� *SaveCommand+6�   �� 5c      $��Clear��6:   $
��Left=�6J   $��232,173,0,0q�6e   $	��Top=�6z   ���	#FFE800FF$��32��6�   $	��131��6�   ��6   �� *ClearCommand+6�   �� 5d      $��Matriculate��6@   $
��Left=�6V   $��276,221,0,0q�6q   $	��Top=�6�   ���	#FFE800FF$��26��6�   $��87��6�   ��6   �� *MatriculateCommand+6�   5f      � 5h      $��2��6    5j      �� 5k      $��20 �6$   �� 5l      $��* �6$   �� 5m      $��17 �6$   �� 5n      $��90 �6$   .+�5q      � $��0��6   .+�5r      �� $
��Left=�6    $��Message to the user��6;   $
��Wrap=�6V   $��Center=�6j   $��42,0,0,0q�6�   5s      � 5u      $��1��6   .+�5v      �� $��WrapWithOverflow=�6?   $��	40,5,37,5q�6_   ���	#FFF0F0F0$
}�True��6�   ��6    �� *MessageToUser+6�   5w      � 5y      $��2��6   .+�5z      �� $
��Left=�6    $��Info to the user��6;   $
��Wrap=�6S   $��Center=�6g   $��41,0,0,0q�6�   $��91��6�   5{      � 5}      $��3��6   .+�5      �� $
��Left=�6    $9��3The number of students signed up at this moment is:��6;   $
��Wrap=�6v   $	��Top=�6�   $��10(�6�   $��	40,-3,0,0q�6�   $��2��6�   �� 5�      $��285,-10,87,71q�6?   $��10(�6V   ��6   �� *Students.Count+6V   �� 5�      $��Center=�6    $����CopyLeft !! All the contents of this program (including, but not limited to, text, logos, content, photographs, audio, buttons, trade names and video) are based on freedom to use, share, modificate and distribute. Do not worry about it!��6=   $
��Wrap=�61  $	��Top=�6E  $��9(�6]  $	��320��6j  $��0,23,0,0q�6v  �� 5�      $��335,-10,35,71q�6:   $��10(�6Q   ��6   �� *	StdInDict+6Q   5�      5�      5�      � 5�   
   $��1��6   .+�5�      &   System.Windows.Controls.DataGrid  $��5q�6`      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 100 6k      AutoGenerateColumns$ False��6}   ��6   �� *
Students+ �� SelectedItem 68   �� *CurrentStudent+.  (System.Windows.Interactivity.Interaction   Triggers 5�      /  )System.Windows.Interactivity.EventTrigger  5�         	EventName$ Loaded��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�      6  0System.Windows.Interactivity.InvokeCommandAction     Command 60   �� *GetInfoCommand+5�         Columns 5�      0	  *System.Windows.Controls.DataGridTextColumn	  5�      ,
  &System.Windows.Controls.DataGridColumn 
  Header$	 Dni��6)    
  Width$	 100 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *Dni+6N   	  5�      $
 Name��6)   $ * 6X    67   �� *CompleteName+6X   	  5�      $ Chair��6)   $ 70 6R    68   �� *Chair+6R   	  5�      $ NumSubjects��6)   $	 100 6^    6>   �� *NumSubjects+6^   	  5�      $ Subjects��6)   $	 250 6^    6;   �� *SubjectsString+6^   4  .System.Windows.Controls.DataGridTemplateColumn  5�      $ 70 6.      CellTemplate 5�      �� 5�      .R�5�   "   �� $
��Edit��6)   ��68   �� *DataContext.EditCommand+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType"  5�      5�        5�      $ 70 6-    5�      �� 5�      .R�5�   "   �� $��Delete��6)   ��6:   �� *DataContext.DeleteCommand+ �� $ FindAncestor=�"  5�      5�      5�      5�      5�      5�      