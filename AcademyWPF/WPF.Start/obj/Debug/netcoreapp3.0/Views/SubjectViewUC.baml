   M S B A M L   `   `   `  ����D  @WPF.Start, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPF.Start.ViewsWPF.Start.Views  5      #    WPF.Start.Views.SubjectViewUC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      )localclr-namespace:WPF.Start.Views  5      .��5
      � ���	#FFB3CFFF  � ColumnDefinitions  5   
   �� 5      $	��400 �6   �� 5      $��* �6   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $��70 �6    �� 5      $	��250 �6    �� 5      $��* �6    .+�5      � $��0��6   .+�5      �� $��Center=�6   $"��WELCOME SUBJECT MAIN PLACE!!��69   $
��Wrap=�6]   $��Center=�6q   $	��342��6�   $��22(�6�   �� 5      $��Center=�6   $4��.- what do you want to teach in your academy? -��69   $
��Wrap=�6o   $	��Top=�6�   $	��342��6�   $��16(�6�   $��0,42,0,0q�6�   5      � 5      $��1��6   $��0,10,0,0q�6    .+�5       �� $
��Left=�6   $��26��65   $��
100,20,0,0q�6A    �� TextWrapping$
 Wrap=�6x   $	��Top=�6�   $	��268��6�   ��6U   �� *Name+ �� Mode$ TwoWay=�6�   �� 5!      $
��Left=�6   $��	26,22,0,0q�67   $��Name:��6J   $
��Wrap=�6W   $	��Top=�6k   $��67��6�   $��22��6�    �� TextAlignment$ Right=�6�   $��14(�6�   �� 5"      $
��Left=�6   $��	26,52,0,0q�67   $��Teacher:��6J   $
��Wrap=�6Z   $	��Top=�6n   $��67��6�   $��22��6�   $ Right=�6�   $��14(�6�   �� 5#      $
��Left=�6   $��26��65   $��
100,78,0,0q�6A   $
 Wrap=�6   $	��Top=�6�   $	��268��6�   ��6U   �� *NumStudents+$ TwoWay=�6�   �� 5%      $��Register��69   $
��Left=�6L   $��100,182,0,0q�6g   $	��Top=�6|   ���	#FF0097FF$��32��6�   $	��134��6�   ��6   �� *SaveCommand+6�   �� 5&      $��Clear��6:   $
��Left=�6J   $��237,182,0,0q�6e   $	��Top=�6z   ���	#FF0097FF$��32��6�   $	��131��6�   ��6   �� *ClearCommand+6�   �� 5'       �� DisplayMemberPath$ CompleteName��6D   $
��Left=�6�   $��
100,51,0,0q�6�   $	��Top=�6�   $	��268��6�   ��6   �� *TeachersToSelect+ �� SelectedValue 6e   �� *TeacherSelected+6�   �� 5(      $
��Left=�6   $��1,80,0,0q�67   $��NumStudents:��6I   $
��Wrap=�6]   $	��Top=�6q   $��92��6�   $��22��6�   $ Right=�6�   $��14(�6�   �� 5)      $
��Left=�6   $��	0,111,0,0q�67   $��Credits:��6J   $
��Wrap=�6Z   $	��Top=�6n   $��92��6�   $��22��6�   $ Right=�6�   $��14(�6�   �� 5*      $
��Left=�6c   $��100,142,0,0q�6~   $	��Top=�6�   $	��268��6�   ��6   �� *SeasonToSelect+ 6B   �� *Season+6�   �� 5+      $
��Left=�6m   $��100,111,0,0q�6�   $	��Top=�6�   $	��268��6�   ��6   �� *CreditsToSelect+ 6C   �� *CreditsSelected+6�   �� 5,      $
��Left=�6   $��
16,142,0,0q�67   $��Season:��6K   $
��Wrap=�6Z   $	��Top=�6n   $��77��6�   $��22��6�   $ Right=�6�   $��14(�6�   5.      � 50      $��2��6    52      �� 53      $��20 �6$   �� 54      $��* �6$   �� 55      $��17 �6$   �� 56      $��90 �6$   .+�59      � $��0��6   .+�5:      �� $
��Left=�6    $��Message to the user��6;   $
��Wrap=�6V   $��Center=�6j   $��42,0,0,0q�6�   5;      � 5=      $��1��6   .+�5>      �� $��WrapWithOverflow=�6?   $��	40,5,37,5q�6_   ���	#FFF0F0F0$
}�True��6�   ��6    �� *MessageToUser+6�   5?      � 5A      $��2��6   .+�5B      �� $
��Left=�6    $��Info to the user��6;   $
��Wrap=�6S   $��Center=�6g   $��41,0,0,0q�6�   $��91��6�   5C      � 5E      $��3��6   .+�5G      �� $
��Left=�6    $9��3The number of subject registered in the academy is:��6;   $
��Wrap=�6v   $	��Top=�6�   $��10(�6�   $��	40,-3,0,0q�6�   $��2��6�   �� 5H      $��285,-10,87,71q�6?   $��10(�6V   ��6   �� *Subjects.Count+6V   �� 5I      $��Center=�6    $����CopyLeft !! All the contents of this program (including, but not limited to, text, logos, content, photographs, audio, buttons, trade names and video) are based on freedom to use, share, modificate and distribute. Do not worry about it!��6=   $
��Wrap=�61  $	��Top=�6E  $��9(�6]  $	��320��6j  $��0,23,0,0q�6v  �� 5J      $��326,-14,45,72q�6:    J� RenderTransformOrigin$ 0.533,0.472&�6Q   ��6   �� *	SbjInDict+6Q   5L      5N      5P      � 5R   
   $��1��6   .+�5T      &   System.Windows.Controls.DataGrid  $��5q�6`      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 100 6k   	   AutoGenerateColumns$	 False��6}   ��6   �� *
Subjects+
 �� SelectedItem
 68   �� *CurrentSubject+.  (System.Windows.Interactivity.Interaction   Triggers 5V      /  )System.Windows.Interactivity.EventTrigger  5W         	EventName$ Loaded��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5X      6  0System.Windows.Interactivity.InvokeCommandAction     Command 60   �� *GetInfoCommand+5Y         Columns 5\      0  *System.Windows.Controls.DataGridTextColumn  5]      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6)      Width$	 100 6P   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 67   �� *Name+6P     5^      $ Teacher��6)   $ * 6Z    6:   �� *TeacherName+6Z     5_      $ Students��6)   $ 80 6\    6;   �� *StudentsMatr+6\     5`      $ MaxStudents��6)   $ 80 6a    6>   �� *NumberStudents+6a     5a      $ Credits��6)   $ 80 6V    6:   �� *	Credits+6V     5b      $ Season��6)   $	 100 6T    69   �� *Season+6T   4
  .System.Windows.Controls.DataGridTemplateColumn
  5d      $ 70 6.    
  CellTemplate 5e      �� 5f      .R�5g   "   �� $
��Edit��6)   ��68   �� *DataContext.EditCommand+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType"  5h      5j      
  5k      $ 70 6-    5l      �� 5m      .R�5n   "   �� $��Delete��6)   ��6:   �� *DataContext.DeleteCommand+ �� $ FindAncestor=�"  5o      5q      5v      5x      5z      5{      