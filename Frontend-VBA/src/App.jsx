import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import InputField from './Components/SubComponents/InputField/InputField'
import Button from './Components/SubComponents/Button/Button'


function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <InputField
        type="text"
        size="medium"
        icon="mail" // change this to change the icon
        placeholder="Email..." //  change this to chane the placeholder of the field
      />

      <Button
      />
    </>
  )
}

export default App
