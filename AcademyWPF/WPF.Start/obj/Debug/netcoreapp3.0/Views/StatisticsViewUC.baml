   M S B A M L   `   `   `  ����D  @WPF.Start, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPF.Start.ViewsWPF.Start.Views  5      &     WPF.Start.Views.StatisticsViewUC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      )localclr-namespace:WPF.Start.Views  5      .��5
      � ���	#FFFFFDCD  � ColumnDefinitions  5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $	��100 �6    �� 5      $��* �6    �� 5      $	��200 �6    .+�5      � $��0��6   .+�5      �� $
��Left=�6   $��BY STUDENT!!��67   $
��Wrap=�6K   $��Bottom=�6_   $	��138��6z   $��22(�6�   $��
254,0,0,28q�6�   �� 5      $
��Left=�6   $1��+- all the information you need by student -��67   $
��Wrap=�6j   $	��Top=�6~   $	��302��6�   $��16(�6�   $��	88,66,0,0q�6�   5      � 5!      $��1��6   .+�5#      &   System.Windows.Controls.DataGrid  $��5,5,5,5q�6d      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 100 6u      AutoGenerateColumns$ False��6�   ��6   �� *
Students+ �� SelectedItem 6<   �� *CurrentStudent+.  (System.Windows.Interactivity.Interaction   Triggers 5%      /  )System.Windows.Interactivity.EventTrigger  5&         	EventName$ Loaded��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5'      6  0System.Windows.Interactivity.InvokeCommandAction     Command 64   �� *GetInfoCommand+5(      	   Columns	 5+      0  *System.Windows.Controls.DataGridTextColumn  5-      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Name��6-      Width$ * 6\   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6;   �� *CompleteName+6\     5.      $
 Chair��6-   $	 100 6V    6<   �� *Chair+6V     5/      $
 Num Subjects��6-   $	 100 6c    6C   �� *NumSubjects+6c   53      55      � 57      $��2��6   .+�59      �� $��Statistics By Student��6E   $
��Left=�6e   $��10,7,0,0q�6�   $	��Top=�6�   ���	#FFFFE800$��32��6�   $	��134��6�   ��6   �� *GetStatisticsStuCommand+6�   �� 5:      $��26��6   $��	279,7,5,0q�6&    �� TextWrapping$
 Wrap=�6V   $	��Top=�6j   ��69   �� *MaxGradeStu+6j   �� 5;      $��173,9,126,0q�6   $��
Max Grade:��61   $
��Wrap=�6C   $	��Top=�6W   $��22��6o    �� TextAlignment$ Right=�6{   $��14(�6�   �� 5<      $��26��6   $��
279,43,5,0q�6&   $
 Wrap=�6W   $	��Top=�6k   ��6:   �� *MinGradeStu+6k   �� 5=      $
��Left=�6   $��
173,45,0,0q�67   $��
Min Grade:��6K   $
��Wrap=�6]   $	��Top=�6q   $	��101��6�   $��22��6�   $ Right=�6�   $��14(�6�   �� 5>      $��26��6   $��	279,0,5,0q�6&   $
 Wrap=�6U   $��Center=�6i   ��69   �� *
AverageStu+6i   �� 5?      $
��Left=�6   $��	173,0,0,0q�67   $��Average:��6J   $
��Wrap=�6Z   $��Center=�6n   $	��101��6�   $��22��6�   $ Right=�6�   $��14(�6�   �� 5@      $��55��6   $��10,56,256,0q�6&   $
 Wrap=�6W   $	��Top=�6k   ��6;   �� *
MessageStu+6k   5B      5D      � 5F   
   $��1��6    5H      �� 5I      $	��100 �6    �� 5J      $��* �6    �� 5K      $	��200 �6    .+�5N      � $��0��6   .+�5P      �� $
��Left=�6   $��BY SUBJECT!!��67   $
��Wrap=�6K   $��Bottom=�6_   $	��138��6z   $��22(�6�   $��
254,0,0,28q�6�   �� 5Q      $
��Left=�6   $2��,- all the information all exams by subject -��67   $
��Wrap=�6k   $	��Top=�6   $	��302��6�   $��16(�6�   $��	88,66,0,0q�6�   5S      � 5U      $��1��6   .+�5W        $��5,5,5,5q�6d   $	 100 6u   $ False��6�   ��6   �� *
Subjects+ 6<   �� *CurrentSubject+ 5Y        5Z      $ Loaded��6)   . 5[         64   �� *GetInfoCommand+5\      	 5_        5a      $

 Name��6-   $	 100 6T    6;   �� *Name+6T     5b      $
 Teacher��6-   $ * 6^    6>   �� *TeacherName+6^     5c      $
 Students��6-   $ 80 6`    6?   �� *StudentsMatr+6`   5g      5i      � 5k      $��2��6   .+�5m      �� $��Statistics By Subject��6E   $
��Left=�6e   $��10,7,0,0q�6�   $	��Top=�6�   ���	#FFFFE800$��32��6�   $	��134��6�   ��6   �� *GetStatisticsSubCommand+6�   �� 5n      $��26��6   $��	279,7,5,0q�6&   $
 Wrap=�6V   $	��Top=�6j   ��69   �� *MaxGradeSub+6j   �� 5o      $��173,9,126,0q�6   $��
Max Grade:��61   $
��Wrap=�6C   $	��Top=�6W   $��22��6o   $ Right=�6{   $��14(�6�   �� 5p      $��26��6   $��
279,43,5,0q�6&   $
 Wrap=�6W   $	��Top=�6k   ��6:   �� *MinGradeSub+6k   �� 5q      $
��Left=�6   $��
173,45,0,0q�67   $��
Min Grade:��6K   $
��Wrap=�6]   $	��Top=�6q   $	��101��6�   $��22��6�   $ Right=�6�   $��14(�6�   �� 5r      $��26��6   $��	279,0,5,0q�6&   $
 Wrap=�6U   $��Center=�6i   ��69   �� *
AverageSub+6i   �� 5s      $
��Left=�6   $��	173,0,0,0q�67   $��Average:��6J   $
��Wrap=�6Z   $��Center=�6n   $	��101��6�   $��22��6�   $ Right=�6�   $��14(�6�   �� 5t      $��55��6   $��10,56,256,0q�6&   $
 Wrap=�6W   $	��Top=�6k   ��6;   �� *
MessageSub+6k   5v      5y      � 5{   
   $��2��6    5}      �� 5~      $	��100 �6    �� 5      $��* �6    �� 5�      $	��200 �6    .+�5�      � $��0��6   .+�5�      �� $
��Left=�6   $��	BY EXAM!!��67   $
��Wrap=�6H   $��Bottom=�6\   $	��104��6w   $��22(�6�   $��
286,0,0,28q�6�   �� 5�      $
��Left=�6   $4��.- if you need to know how your jobs has been -��67   $
��Wrap=�6m   $	��Top=�6�   $	��329��6�   $��16(�6�   $��	61,66,0,0q�6�   5�      � 5�      $��1��6   .+�5�        $��5,5,5,5q�6^   $	 100 6o   $ False��6�   ��6   �� *Exams+ 69   �� *CurrentExam+ 5�        5�      $ Loaded��6)   . 5�         64   �� *GetInfoCommand+5�      	 5�        5�      $

 Name��6-   $	 100 6T    6;   �� *Name+6T     5�      $

 Date��6-   $ * 6T    6;   �� *Date+6T     5�      $
 Subject��6-   $ 80 6_    6>   �� *Subject.Name+6_   5�      5�      � 5�      $��2��6   .+�5�      �� $��Statistics By Exam��6E   $
��Left=�6b   $��10,7,0,0q�6}   $	��Top=�6�   ���	#FFFFE800$��32��6�   $	��134��6�   ��6   �� *GetStatisticsExaCommand+6�   �� 5�      $��26��6   $��	279,7,5,0q�6&   $
 Wrap=�6V   $	��Top=�6j   ��69   �� *MaxGradeExa+6j   �� 5�      $��173,9,126,0q�6   $��
Max Grade:��61   $
��Wrap=�6C   $	��Top=�6W   $��22��6o   $ Right=�6{   $��14(�6�   �� 5�      $��26��6   $��
279,43,5,0q�6&   $
 Wrap=�6W   $	��Top=�6k   ��6:   �� *MinGradeExa+6k   �� 5�      $
��Left=�6   $��
173,45,0,0q�67   $��
Min Grade:��6K   $
��Wrap=�6]   $	��Top=�6q   $	��101��6�   $��22��6�   $ Right=�6�   $��14(�6�   �� 5�      $��26��6   $��	279,0,5,0q�6&   $
 Wrap=�6U   $��Center=�6i   ��69   �� *
AverageExa+6i   �� 5�      $
��Left=�6   $��	173,0,0,0q�67   $��Average:��6J   $
��Wrap=�6Z   $��Center=�6n   $	��101��6�   $��22��6�   $ Right=�6�   $��14(�6�   �� 5�      $��55��6   $��10,56,256,0q�6&   $
 Wrap=�6W   $	��Top=�6k   ��6;   �� *
MessageExa+6k   5�      5�      5�      5�      