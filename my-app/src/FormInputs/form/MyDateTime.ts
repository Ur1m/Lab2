import { useField } from 'formik';
import React from 'react';
import { Form, Label, Placeholder, Select } from 'semantic-ui-react';
import Datepicker,{ReactDatePickerProps} from 'react-datepicker';

interface Props {
    placeholder: string;
    name: string;
    options:any;
    label?: string;
}

export default function MyDateTime(props: Partial <ReactDatePickerProps>){
    const [field, meta,helpers] = useField(props.name!);
    return (
      "text"
    )
}