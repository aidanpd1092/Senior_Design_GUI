function S = spiro_data_reading(Subject_number, trial, display_fig);


folder_name = ['C:\Users\ArjunS\Desktop\Trials\'];
file_name =[num2str(Subject_number) '.dt'];
save_name =['Spiro-Sub' num2str(Subject_number) '-Straw' '.mat'];

% save the results in a file
save_res = 1;

% open the file for read out
fileID = fopen([folder_name file_name],'r');

readout = fread(fileID, 13, 'int32=>double', 0,'l');

ID = readout(1);
trial_nr = readout(2);
gender = readout(8);
country_code = readout(10);
age = readout(11);
height = readout(12);
weight = readout(13);

readout = fread(fileID,29, 'char=>char',0);
timestamp = readout(1:16).';
filename = readout(22:29);

to_rem = [];
for i = 1:8
    if(double(filename(i)) == 0)
        to_rem = [to_rem i];
    else
        break
    end
end
filename(to_rem) = [];
filename = filename.';

% set the pointer 95 bytes further
fseek(fileID, 95, 'cof');
% dummy = fread(fileID, 95, 'char=>char',0);

% read out smoker and drug variables
smoker = fread(fileID, 1, 'int32=>double', 0,'l');
drug = fread(fileID, 1, 'int32=>double', 0,'l');

% set the file pointer 20 bytes further
fseek(fileID, 20, 'cof');
% dummy = fread(fileID, 20, 'char=>char',0);

% read out pulmonary parameters
FVC = fread(fileID, 1, 'double=>double', 0,'l');
FEV1 = fread(fileID, 1, 'double=>double', 0,'l');
PEF = fread(fileID, 1, 'double=>double', 0,'l');
FEV1percent = fread(fileID, 1, 'double=>double', 0,'l');
FEF25 = fread(fileID, 1, 'double=>double', 0,'l');
fseek(fileID, 8, 'cof');
FEF75 = fread(fileID, 1, 'double=>double', 0,'l');
FEF2575 = fread(fileID, 1, 'double=>double', 0,'l');

fseek(fileID, 8, 'cof');
readout_to_y = fread(fileID, 1, 'int32=>double', 0,'l');
fseek(fileID, 4, 'cof');
volume_data_temp = fread(fileID, readout_to_y*2, 'int32=>double', 0,'l');

% close the file after read out
fclose(fileID);

volume_data = zeros(readout_to_y,2);
for count=1:readout_to_y*2
    volume_data(ceil(count/2),2-mod(count,2)) = volume_data_temp(count);
end

volume_data = volume_data+[zeros(readout_to_y,1) ones(readout_to_y,1)];
volume_data = [0 0; volume_data];

time_vect = volume_data(:,1)./100000;
volume_data = volume_data(:,2); 


below_1 = find(time_vect < 1);
below_1 = below_1(end);
above_1 = find(time_vect >= 1);

%if(~isempty(above_1) && time_vect(end)>=1 )
if(~isempty(above_1) )
    above_1 = above_1(1);
    
    one = (1-time_vect(below_1))/(time_vect(above_1)-time_vect(below_1));
    
    % use the volume factor calculated by optimization
    volume_fact = 0.013202082696648;
    volume_data = volume_data.*volume_fact;
    
    FEV1_error = (one*volume_data(below_1)+(1-one)*volume_data(above_1)-FEV1);
    FVC_error = volume_data(end) - FVC;
    
    if(save_res == 1)
        save([folder_name save_name],'FEF25','height','FEF2575','trial_nr','FEF75','country_code',...
            'volume_data','FEV1','drug','readout_to_y','FEV1percent','save_name',...
            'volume_fact','FVC','file_name','weight','ID','filename','smoker','PEF','folder_name',...
            'time_vect','age','gender','timestamp','FEV1_error','FVC_error');
    end
end


S = load([folder_name save_name]);
if(display_fig == 1)
    plot(S.time_vect, S.volume_data)
    grid on
    title('FEV1 test from Spirometer (Bubble Tea Straw)')
    xlabel('Time (sec)')
    ylabel('Volume (Lit)')
    hold on
end
plot(1,FEV1,'ro')
plot(time_vect(length(time_vect)), FVC, 'go')

end