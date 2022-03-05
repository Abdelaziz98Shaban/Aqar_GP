import {
  Flex,
  Box,
  FormControl,
  FormLabel,
  Input,
  InputGroup,
  HStack,
  InputRightElement,
  Stack,
  Button,
  Heading,
  Text,
  useColorModeValue,
  Alert,
  AlertIcon,
  AlertTitle,
  AlertDescription,
  CloseButton,
} from "@chakra-ui/react";
import { useState } from "react";
import { ViewIcon, ViewOffIcon } from "@chakra-ui/icons";
import { Link } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { register } from "../redux/auth";

export default function Signup() {
  const [showPassword, setShowPassword] = useState(false);

  const [account, setAccount] = useState({
    firstName: "",
    lastName: "",
    address: "",
    mobileNumber: "",
    username: "",
    email: "",
    password: "",
  });

  const { error } = useSelector(state => state.auth);
  const dispatch = useDispatch();

  const registerHandler = e => {
    e.preventDefault();
    dispatch(register(account));
  };

  const inputChangeHandler = ({ currentTarget: input }) => {
    const enteredAccount = { ...account };
    enteredAccount[input.name] = input.value;
    setAccount(enteredAccount);
  };

  return (
    <Flex
      minH={"100vh"}
      align={"center"}
      justify={"center"}
      bg={useColorModeValue("gray.50", "gray.800")}
    >
      <Stack spacing={8} mx={"auto"} maxW={"lg"} py={12} px={6}>
        <Stack align={"center"}>
          <Heading fontSize={"4xl"} textAlign={"center"}>
            Sign up
          </Heading>
          {error && (
            <Alert status='error'>
              <AlertIcon />
              <AlertTitle mr={2}>{error}</AlertTitle>
            </Alert>
          )}
        </Stack>
        <Box
          rounded={"lg"}
          bg={useColorModeValue("white", "gray.700")}
          boxShadow={"lg"}
          p={8}
        >
          <form onSubmit={registerHandler}>
            <Stack spacing={4}>
              <HStack>
                <Box>
                  <FormControl id='firstName' isRequired>
                    <FormLabel>First Name</FormLabel>
                    <Input
                      type='text'
                      name='firstName'
                      value={account.firstName}
                      onChange={inputChangeHandler}
                    />
                  </FormControl>
                </Box>
                <Box>
                  <FormControl id='lastName' isRequired>
                    <FormLabel>Last Name</FormLabel>
                    <Input
                      type='text'
                      name='lastName'
                      value={account.lastName}
                      onChange={inputChangeHandler}
                    />
                  </FormControl>
                </Box>
              </HStack>
              <FormControl id='usename' isRequired>
                <FormLabel>User Name</FormLabel>
                <Input
                  type='text'
                  name='username'
                  value={account.username}
                  onChange={inputChangeHandler}
                />
              </FormControl>
              <FormControl id='mobileNumber' isRequired>
                <FormLabel>Mobile Number</FormLabel>
                <Input
                  type='number'
                  name='mobileNumber'
                  value={account.mobileNumber}
                  onChange={inputChangeHandler}
                />
              </FormControl>
              <FormControl id='address' isRequired>
                <FormLabel>Address - Location</FormLabel>
                <Input
                  type='text'
                  name='address'
                  value={account.address}
                  onChange={inputChangeHandler}
                />
              </FormControl>
              <FormControl id='email' isRequired>
                <FormLabel>Email address</FormLabel>
                <Input
                  type='email'
                  name='email'
                  value={account.email}
                  onChange={inputChangeHandler}
                />
              </FormControl>
              <FormControl id='password' isRequired>
                <FormLabel>Password</FormLabel>
                <InputGroup>
                  <Input
                    type={showPassword ? "text" : "password"}
                    name='password'
                    value={account.password}
                    onChange={inputChangeHandler}
                  />
                  <InputRightElement h={"full"}>
                    <Button
                      variant={"ghost"}
                      onClick={() =>
                        setShowPassword(showPassword => !showPassword)
                      }
                    >
                      {showPassword ? <ViewIcon /> : <ViewOffIcon />}
                    </Button>
                  </InputRightElement>
                </InputGroup>
              </FormControl>
              <Stack spacing={10} pt={2}>
                <Button
                  type='submit'
                  loadingText='Submitting'
                  size='lg'
                  bg={"blue.400"}
                  color={"white"}
                  _hover={{
                    bg: "blue.500",
                  }}
                >
                  Sign up
                </Button>
              </Stack>
              <Stack pt={6}>
                <Flex gap='2' justifyContent='center'>
                  Already a user?{" "}
                  <Link to='/signin'>
                    <Text color={"blue.400"}>Login</Text>
                  </Link>
                </Flex>
              </Stack>
            </Stack>
          </form>
        </Box>
      </Stack>
    </Flex>
  );
}
