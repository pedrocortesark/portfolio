   M S B A M L   `   `   `  ����D  @WPF.Start, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPF.Start.ViewsWPF.Start.Views  5      #    WPF.Start.Views.TeacherViewUC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      )localclr-namespace:WPF.Start.Views  5      .��5
      � ���	#FFE3FFE6  � ColumnDefinitions  5   
   �� 5      $	��400 �6   �� 5      $��* �6   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $��70 �6    �� 5      $	��250 �6    �� 5      $��* �6    .+�5      � $��0��6   .+�5      �� $��Center=�6   $'��!SCHHH... THIS IS TEACHERS' SITE!!��69   $
��Wrap=�6b   $��Center=�6v   $	��338��6�   $��22(�6�   �� 5      $��Center=�6   $2��,- who are handle our children's education? -��69   $
��Wrap=�6m   $	��Top=�6�   $	��320��6�   $��16(�6�   $��0,42,0,0q�6�   5      � 5      $��1��6   $��0,10,0,0q�6    .+�5       �� $
��Left=�6   $��	28,22,0,0q�67   $��Name:��6J   $
��Wrap=�6W   $	��Top=�6k   $��60��6�   $��26��6�    �� TextAlignment$ Right=�6�   $��14(�6�   �� 5!      $
��Left=�6   $��	15,55,0,0q�67   $��	LastName:��6J   $
��Wrap=�6[   $	��Top=�6o   $��73��6�   $��22��6�   $ Right=�6�   $��14(�6�   �� 5"      $
��Left=�6   $��	15,88,0,0q�67   $��
LastName2:��6J   $
��Wrap=�6\   $	��Top=�6p   $��73��6�   $��20��6�   $ Right=�6�   $��14(�6�   �� 5$      $
��Left=�6   $��26��65   $��	98,20,0,0q�6A    �� TextWrapping$
 Wrap=�6w   $	��Top=�6�   $	��268��6�   ��6T   �� *Name+ �� Mode$ TwoWay=�6�   �� 5%      $
��Left=�6   $��26��65   $��	98,53,0,0q�6A   $
 Wrap=�6|   $	��Top=�6�   $	��268��6�   ��6T   �� *	LastName1+$ TwoWay=�6�   �� 5&      $
��Left=�6   $��26��65   $��	98,84,0,0q�6A   $
 Wrap=�6|   $	��Top=�6�   $	��268��6�   ��6T   �� *	LastName2+$ TwoWay=�6�   �� 5'      $
��Left=�6l   $��
98,120,0,0q�6�   $	��Top=�6�   $	��268��6�   ��6   �� *CreditsToSelect+ �� SelectedItem 6C   �� *CreditsSelected+6�   �� 5)      $��Register��69   $
��Left=�6L   $��
98,153,0,0q�6g   $	��Top=�6{   ���	#FF17FF00$��32��6�   $	��134��6�   ��6   �� *SaveCommand+6�   �� 5*      $��Clear��6:   $
��Left=�6J   $��235,153,0,0q�6e   $	��Top=�6z   ���	#FF17FF00$��32��6�   $	��131��6�   ��6   �� *ClearCommand+6�   �� 5+      $
��Left=�6   $��	4,120,0,0q�67   $��MaxCredits:��6J   $
��Wrap=�6]   $	��Top=�6q   $��84��6�   $��20��6�   $ Right=�6�   $��14(�6�   5-      � 5/      $��2��6    51      �� 52      $��20 �6$   �� 53      $��* �6$   �� 54      $��17 �6$   �� 55      $��90 �6$   .+�58      � $��0��6   .+�59      �� $
��Left=�6    $��Message to the user��6;   $
��Wrap=�6V   $��Center=�6j   $��42,0,0,0q�6�   5:      � 5<      $��1��6   .+�5=      �� $��WrapWithOverflow=�6?   $��	40,5,37,5q�6_   ���	#FFF0F0F0$
}�True��6�   ��6    �� *MessageToUser+6�   5>      � 5@      $��2��6   .+�5A      �� $
��Left=�6    $��Info to the user��6;   $
��Wrap=�6S   $��Center=�6g   $��41,0,0,0q�6�   $��91��6�   5B      � 5D      $��3��6   .+�5F      �� $
��Left=�6    $5��/The number of teachers hired at this moment is:��6;   $
��Wrap=�6r   $	��Top=�6�   $��10(�6�   $��	40,-3,0,0q�6�   $��2��6�   �� 5G      $��285,-10,87,71q�6?   $��10(�6V   ��6   �� *Teachers.Count+6V   �� 5H      $��Center=�6    $����CopyLeft !! All the contents of this program (including, but not limited to, text, logos, content, photographs, audio, buttons, trade names and video) are based on freedom to use, share, modificate and distribute. Do not worry about it!��6=   $
��Wrap=�61  $	��Top=�6E  $��9(�6]  $	��320��6j  $��0,23,0,0q�6v  �� 5I      $��335,-10,35,71q�6:   $��10(�6Q   ��6   �� *	TeaInDict+6Q   5K      5M      5P      � 5R   
   $��1��6   .+�5T      &   System.Windows.Controls.DataGrid  $��5q�6`      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 100 6k      AutoGenerateColumns$ False��6}   ��6   �� *
Teachers+ 68   �� *CurrentTeacher+.  (System.Windows.Interactivity.Interaction   Triggers 5V      /  )System.Windows.Interactivity.EventTrigger  5W      	   	EventName$	 Loaded��6%   .  (System.Windows.Interactivity.TriggerBase
   Actions.
 5X      6  0System.Windows.Interactivity.InvokeCommandAction     Command 60   �� *GetInfoCommand+5Y         Columns 5\      0  *System.Windows.Controls.DataGridTextColumn  5^      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6)      Width$ * 6X   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 67   �� *CompleteName+6X     5_      $ Credits��6)   $ 80 6\    6:   �� *NumberCredits+6\     5`      $ 
MaxCredits��6)   $ 80 6\    6=   �� *
MaxCredits+6\     5a      $ NumSubjects��6)   $ 80 6a    6>   �� *NumberSubjects+6a     5b      $ Subjects��6)   $	 250 6^    6;   �� *SubjectsString+6^   4
  .System.Windows.Controls.DataGridTemplateColumn
  5d      $ 70 6.    
  CellTemplate 5e      �� 5f      .R�5g   "   �� $
��Edit��6)   ��68   �� *DataContext.EditCommand+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType"  5h      5j      
  5l      $ 70 6-    5m      �� 5n      .R�5o   "   �� $��Delete��6)   ��6:   �� *DataContext.DeleteCommand+ �� $ FindAncestor=�"  5p      5r      5v      5x      5z      5{      