import {
  Stack,
  Flex,
  Text,
  VStack,
  useBreakpointValue,
} from "@chakra-ui/react";

const Home = () => {
  return (
    <Flex
      w={"full"}
      h={"100vh"}
      backgroundImage='./assets/images/hero.jpg'
      backgroundSize={"cover"}
      backgroundPosition={"center center"}
    >
      <VStack
        w={"full"}
        justify={"center"}
        px={useBreakpointValue({ base: 4, md: 8 })}
        bgGradient={"linear(to-r, blackAlpha.600, transparent)"}
      >
        <Stack maxW={"2xl"} align={"flex-start"} spacing={6}>
          <Text
            color={"white"}
            fontWeight={700}
            lineHeight={1.2}
            fontSize={useBreakpointValue({ base: "3xl", md: "5xl" })}
          >
            Whether you’re buying, selling or renting, we can help you settle to
            your perfect home.
          </Text>
        </Stack>
      </VStack>
    </Flex>
  );
};

export default Home;
