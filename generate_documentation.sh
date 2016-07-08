doxygen doxyfile

TARGET_BRANCH="gh-pages"
mkdir $TARGET_BRANCH
cd $TARGET_BRANCH
 
git clone -b $TARGET_BRANCH --single-branch https://github.com/g8y3e/backoff-chasrp.git

cd void-engine
cp -r ../../docs/html/* .

git add .
git commit -m "Deploy to GitHub Pages"

# Now that we're all set up, we can push.
git push origin $TARGET_BRANCH

cd ../../
rm -r -f $TARGET_BRANCH
rm -r -f docs