import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import InputField from './Components/SubComponents/InputField/InputField'
import Button from './Components/SubComponents/Button/Button'
import Switch from './Components/SubComponents/Switch/Switch'
import RadioButton from './Components/SubComponents/RadioButton/RadioButton'
import Checkbox from './Components/SubComponents/Checkbox/Checkbox'


function App() {
  const [count, setCount] = useState(0)

  const [isChecked, setIsChecked] = useState(false);
  const [selectedOption, setSelectedOption] = useState('');

  const handleToggle = () => {
    setIsChecked(!isChecked);
  };

  // Handler function for radio button change
  const handleRadioChange = (e) => {
    setSelectedOption(e.target.value);
  };

  return (
    <>
    <h1>Input Fields</h1>
      <InputField
        type="password"
        size="medium"
        icon="lock" // change this to change the icon
        placeholder="Password..." //  change this to chane the placeholder of the field
      />
      <h1>Short Buttons</h1>
      <Button
        variant='secondary'
        value='Click me'
      />
      <hr />
      <Button
        variant='primary'
        value='Click me'
      />
      <hr />
      <h1>Long Buttons</h1>
      <Button
        variant='secondary'
        value='Click me'
        fullWidth
      />
      <hr />
      <Button
        variant='primary'
        value='Click me'
        fullWidth
      />

      <div>
        <h1>Switch Component</h1>
        <Switch variant="primary" checked={isChecked} onChange={handleToggle} />
        <Switch variant="secondary" checked={isChecked} onChange={handleToggle} />
        <Switch variant="disabled" checked={isChecked} onChange={handleToggle} />
      </div>

      <hr />

      <div>
      <h1>Radio Button Component</h1>
      {/* Primary Radio Button Group */}
      <RadioButton
        variant="primary"
        name="options"
        value="option1"
        checked={selectedOption === 'option1'}
        onChange={handleRadioChange}
      />
      <span>Option 1</span>

      <RadioButton
        variant="secondary"
        name="options"
        value="option2"
        checked={selectedOption === 'option2'}
        onChange={handleRadioChange}
      />
      <span>Option 2</span>

      {/* Secondary Radio Button Group */}
      <RadioButton
        variant="disabled"
        name="options"
        value="option3"
        checked={selectedOption === 'option3'}
        onChange={handleRadioChange}
      />
      <span>Option 3</span>
    </div>

    <hr />
    <div>
      <Checkbox variant="primary" label="Primary Checkbox" onChange={(checked) => console.log('Primary checked:', checked)} />
      <Checkbox variant="secondary" label="Secondary Checkbox" onChange={(checked) => console.log('Secondary checked:', checked)} />
    </div>
    </>
  )
}

export default App
